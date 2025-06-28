using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Pago
    {
        // Necesarios
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public EstadoPago Estado { get; set; }
        public int ReservaId { get; set; }
        public string ApplicationUserId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Reserva Reserva { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
