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
    public class BoletosController : Controller
    {
        private readonly Context1 _context;

        public BoletosController(Context1 context)
        {
            _context = context;
        }

        // GET: Boletos
        public async Task<IActionResult> Index()
        {
            var context1 = _context.Boletos.Include(b => b.Asiento).Include(b => b.Reserva).Include(b => b.Viaje);
            return View(await context1.ToListAsync());
        }

        // GET: Boletos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.Asiento)
                .Include(b => b.Reserva)
                .Include(b => b.Viaje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // GET: Boletos/Create
        public IActionResult Create()
        {
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Codigo");
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id");
            ViewData["ViajeId"] = new SelectList(_context.Viajes, "Id", "Id");
            return View();
        }

        // POST: Boletos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria,TipoAsiento,PrecioFinal,FechaEmision,Estado,ReservaId,ViajeId,AsientoId")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Codigo", boleto.AsientoId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", boleto.ReservaId);
            ViewData["ViajeId"] = new SelectList(_context.Viajes, "Id", "Id", boleto.ViajeId);
            return View(boleto);
        }

        // GET: Boletos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Codigo", boleto.AsientoId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", boleto.ReservaId);
            ViewData["ViajeId"] = new SelectList(_context.Viajes, "Id", "Id", boleto.ViajeId);
            return View(boleto);
        }

        // POST: Boletos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria,TipoAsiento,PrecioFinal,FechaEmision,Estado,ReservaId,ViajeId,AsientoId")] Boleto boleto)
        {
            if (id != boleto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletoExists(boleto.Id))
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
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Codigo", boleto.AsientoId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", boleto.ReservaId);
            ViewData["ViajeId"] = new SelectList(_context.Viajes, "Id", "Id", boleto.ViajeId);
            return View(boleto);
        }

        // GET: Boletos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.Asiento)
                .Include(b => b.Reserva)
                .Include(b => b.Viaje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // POST: Boletos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto != null)
            {
                _context.Boletos.Remove(boleto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletoExists(int id)
        {
            return _context.Boletos.Any(e => e.Id == id);
        }
    }
}
