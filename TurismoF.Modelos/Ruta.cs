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
        public decimal PrecioBase { get; set; }
        public string Color { get; set; }
        public string Coordenadas { get; set; }

        // No necesarios para ingresar desde Swagger
        public List<Viaje> Viajes { get; set; }
        public List<PrecioConfiguracion> Precios { get; set; }
    }
}
