using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class ApplicationUser:IdentityUser
    {
        // Necesarios
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaRegistro { get; set; }

        // No necesarios para ingresar desde Swagger
        public List<Reserva> Reservas { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
