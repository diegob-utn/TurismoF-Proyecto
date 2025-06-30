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
    public class VagonesController : Controller
    {
        private readonly Context1 _context;

        public VagonesController(Context1 context)
        {
            _context = context;
        }

        // GET: Vagones
        public async Task<IActionResult> Index()
        {
            var context1 = _context.Vagones.Include(v => v.Tren);
            return View(await context1.ToListAsync());
        }

        // GET: Vagones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagon = await _context.Vagones
                .Include(v => v.Tren)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagon == null)
            {
                return NotFound();
            }

            return View(vagon);
        }

        // GET: Vagones/Create
        public IActionResult Create()
        {
            ViewData["TrenId"] = new SelectList(_context.Trenes, "Id", "Nombre");
            return View();
        }

        // POST: Vagones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,TipoVagon,EsPreferencial,TrenId")] Vagon vagon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vagon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrenId"] = new SelectList(_context.Trenes, "Id", "Nombre", vagon.TrenId);
            return View(vagon);
        }

        // GET: Vagones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagon = await _context.Vagones.FindAsync(id);
            if (vagon == null)
            {
                return NotFound();
            }
            ViewData["TrenId"] = new SelectList(_context.Trenes, "Id", "Nombre", vagon.TrenId);
            return View(vagon);
        }

        // POST: Vagones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,TipoVagon,EsPreferencial,TrenId")] Vagon vagon)
        {
            if (id != vagon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagonExists(vagon.Id))
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
            ViewData["TrenId"] = new SelectList(_context.Trenes, "Id", "Nombre", vagon.TrenId);
            return View(vagon);
        }

        // GET: Vagones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagon = await _context.Vagones
                .Include(v => v.Tren)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagon == null)
            {
                return NotFound();
            }

            return View(vagon);
        }

        // POST: Vagones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vagon = await _context.Vagones.FindAsync(id);
            if (vagon != null)
            {
                _context.Vagones.Remove(vagon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagonExists(int id)
        {
            return _context.Vagones.Any(e => e.Id == id);
        }
    }
}
