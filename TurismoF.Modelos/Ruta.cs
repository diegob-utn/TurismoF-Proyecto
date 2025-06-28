using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Ruta
    {
        // Necesarios
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ColorMapa { get; set; }
        public string Coordenadas { get; set; } // Para Google Maps (polyline)

        // FKs
        // (Ninguna)

        // Navegadores
        public List<Viaje>? Viajes { get; set; }
        public List<PrecioConfiguracion>? PreciosConfiguracion { get; set; }
    }
}
