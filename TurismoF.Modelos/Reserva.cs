using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Reserva
    {
        // Necesarios
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public EstadoReserva Estado { get; set; }
        public int TotalBoletos { get; set; }
        public decimal MontoTotal { get; set; }
        public string ApplicationUserId { get; set; }
        public int ViajeId { get; set; }

        // No necesarios para ingresar desde Swagger
        public ApplicationUser ApplicationUser { get; set; }
        public Viaje Viaje { get; set; }
        public List<Boleto> Boletos { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
