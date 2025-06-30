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
        public string colorRuta { get; set; }
        public double LatInicio { get; set; }
        public double LonInicio { get; set; }
        public double LatFin { get; set; }
        public double LonFin { get; set; }

        // FKs
        // (Ninguna)

        // Navegadores
        public List<Viaje>? Viajes { get; set; }
        public List<PrecioConfiguracion>? PreciosConfiguracion { get; set; }
    }
}