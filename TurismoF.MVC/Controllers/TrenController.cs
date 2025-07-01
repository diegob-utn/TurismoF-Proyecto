using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoF.Data.Data;
using TurismoF.Modelos;

namespace TurismoF.MVC.Controllers
{
    public class TrenController : Controller
    {
        private readonly Context1 _context;

        public TrenController(Context1 context)
        {
            _context = context;
        }

        // GET: Lista de trenes disponibles
        public async Task<IActionResult> Index()
        {
            var trenes = await _context.Trenes
                .Where(t => t.Estado == EstadoTren.Activo)
                .Include(t => t.Vagones)
                .ToListAsync();
            
            return View(trenes);
        }

        // GET: Selección de asientos para un tren específico
        public async Task<IActionResult> Asientos(int trenId, int? vagonId = null)
        {
            var tren = await _context.Trenes
                .Include(t => t.Vagones)
                    .ThenInclude(v => v.Asientos)
                        .ThenInclude(a => a.Boletos)
                .FirstOrDefaultAsync(t => t.Id == trenId);

            if (tren == null)
            {
                return NotFound();
            }

            // Si no se especifica vagón, usar el primero
            if (vagonId == null && tren.Vagones?.Any() == true)
            {
                vagonId = tren.Vagones.First().Id;
            }

            var vagon = tren.Vagones?.FirstOrDefault(v => v.Id == vagonId);
            if (vagon == null)
            {
                return NotFound();
            }

            ViewBag.Tren = tren;
            ViewBag.VagonSeleccionado = vagon;
            
            return View(vagon);
        }

        // API: Obtener estado de asientos de un vagón
        [HttpGet]
        public async Task<IActionResult> EstadoAsientos(int vagonId)
        {
            var vagon = await _context.Vagones
                .Include(v => v.Asientos)
                    .ThenInclude(a => a.Boletos)
                .FirstOrDefaultAsync(v => v.Id == vagonId);

            if (vagon == null)
            {
                return NotFound();
            }

            var asientos = vagon.Asientos?.Select(a => new
            {
                id = a.Id,
                codigo = a.Codigo,
                fila = a.Fila,
                numero = a.Numero,
                tipoAsiento = a.TipoAsiento.ToString(),
                ubicacion = a.Ubicacion.ToString(),
                disponible = a.Boletos?.Any(b => b.Estado == EstadoBoleto.Disponible) == true,
                reservado = a.Boletos?.Any(b => b.Estado == EstadoBoleto.Reservado) == true
            }).ToList();

            return Json(asientos);
        }

        // API: Reservar asientos seleccionados
        [HttpPost]
        public async Task<IActionResult> ReservarAsientos([FromBody] List<int> asientoIds)
        {
            try
            {
                var asientos = await _context.Asientos
                    .Include(a => a.Boletos)
                    .Where(a => asientoIds.Contains(a.Id))
                    .ToListAsync();

                foreach (var asiento in asientos)
                {
                    var boletoDisponible = asiento.Boletos?.FirstOrDefault(b => b.Estado == EstadoBoleto.Disponible);
                    if (boletoDisponible != null)
                    {
                        boletoDisponible.Estado = EstadoBoleto.Reservado;
                        boletoDisponible.FechaEmision = DateTime.Now;
                    }
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Asientos reservados correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al reservar asientos: " + ex.Message });
            }
        }
    }
}