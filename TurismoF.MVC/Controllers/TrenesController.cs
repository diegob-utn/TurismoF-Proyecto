using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurismoF.Data.Data;
using TurismoF.Modelos;

namespace TurismoF.MVC.Controllers
{
    public class TrenesController : Controller
    {
        private readonly Context1 _context;

        public TrenesController(Context1 context)
        {
            _context = context;
        }

        // GET: Trenes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trenes.ToListAsync());
        }

        // GET: Trenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tren = await _context.Trenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tren == null)
            {
                return NotFound();
            }

            return View(tren);
        }

        // GET: Trenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado,CantidadVagones,CantidadAsientosPorVagon")] Tren tren)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tren);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tren);
        }

        // GET: Trenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tren = await _context.Trenes.FindAsync(id);
            if (tren == null)
            {
                return NotFound();
            }
            return View(tren);
        }

        // POST: Trenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado,CantidadVagones,CantidadAsientosPorVagon")] Tren tren)
        {
            if (id != tren.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tren);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenExists(tren.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tren);
        }

        // GET: Trenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tren = await _context.Trenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tren == null)
            {
                return NotFound();
            }

            return View(tren);
        }

        // POST: Trenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tren = await _context.Trenes.FindAsync(id);
            if (tren != null)
            {
                _context.Trenes.Remove(tren);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenExists(int id)
        {
            return _context.Trenes.Any(e => e.Id == id);
        }
    }
}
