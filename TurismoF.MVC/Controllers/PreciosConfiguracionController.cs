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
    public class PreciosConfiguracionController : Controller
    {
        private readonly Context1 _context;

        public PreciosConfiguracionController(Context1 context)
        {
            _context = context;
        }

        // GET: PreciosConfiguracion
        public async Task<IActionResult> Index()
        {
            var context1 = _context.PreciosConfiguracion.Include(p => p.Ruta);
            return View(await context1.ToListAsync());
        }

        // GET: PreciosConfiguracion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioConfiguracion = await _context.PreciosConfiguracion
                .Include(p => p.Ruta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (precioConfiguracion == null)
            {
                return NotFound();
            }

            return View(precioConfiguracion);
        }

        // GET: PreciosConfiguracion/Create
        public IActionResult Create()
        {
            ViewData["RutaId"] = new SelectList(_context.Rutas, "Id", "ColorMapa");
            return View();
        }

        // POST: PreciosConfiguracion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria,TipoAsiento,PrecioBase,Descuento,RutaId")] PrecioConfiguracion precioConfiguracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precioConfiguracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RutaId"] = new SelectList(_context.Rutas, "Id", "ColorMapa", precioConfiguracion.RutaId);
            return View(precioConfiguracion);
        }

        // GET: PreciosConfiguracion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioConfiguracion = await _context.PreciosConfiguracion.FindAsync(id);
            if (precioConfiguracion == null)
            {
                return NotFound();
            }
            ViewData["RutaId"] = new SelectList(_context.Rutas, "Id", "ColorMapa", precioConfiguracion.RutaId);
            return View(precioConfiguracion);
        }

        // POST: PreciosConfiguracion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria,TipoAsiento,PrecioBase,Descuento,RutaId")] PrecioConfiguracion precioConfiguracion)
        {
            if (id != precioConfiguracion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precioConfiguracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecioConfiguracionExists(precioConfiguracion.Id))
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
            ViewData["RutaId"] = new SelectList(_context.Rutas, "Id", "ColorMapa", precioConfiguracion.RutaId);
            return View(precioConfiguracion);
        }

        // GET: PreciosConfiguracion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioConfiguracion = await _context.PreciosConfiguracion
                .Include(p => p.Ruta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (precioConfiguracion == null)
            {
                return NotFound();
            }

            return View(precioConfiguracion);
        }

        // POST: PreciosConfiguracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precioConfiguracion = await _context.PreciosConfiguracion.FindAsync(id);
            if (precioConfiguracion != null)
            {
                _context.PreciosConfiguracion.Remove(precioConfiguracion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecioConfiguracionExists(int id)
        {
            return _context.PreciosConfiguracion.Any(e => e.Id == id);
        }
    }
}
