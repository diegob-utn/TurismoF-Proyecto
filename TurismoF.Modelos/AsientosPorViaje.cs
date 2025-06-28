using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class AsientosPorViaje
    {
        // Necesarios
        public int Id { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        public int TotalAsientos { get; set; }
        public int AsientosDisponibles { get; set; }
        public int ViajeId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Viaje Viaje { get; set; }
    }
}
