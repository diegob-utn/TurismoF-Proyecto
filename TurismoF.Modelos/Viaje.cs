using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Viaje
    {
        // Necesarios
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public EstadoViaje Estado { get; set; }

        // FKs
        public int TrenId { get; set; }
        public int RutaId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Tren Tren { get; set; }
        public Ruta Ruta { get; set; }
        public List<AsientosPorViaje> AsientosPorViaje { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Boleto> Boletos { get; set; }
    }
}
