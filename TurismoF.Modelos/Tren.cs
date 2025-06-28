using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Tren
    {
        // Necesarios
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public int CantidadAsientosPreferencial { get; set; }
        public int CantidadAsientosEconomico { get; set; }
        public EstadoTren Estado { get; set; }

        // No necesarios para ingresar desde Swagger
        public List<Vagon> Vagones { get; set; }
        public List<Viaje> Viajes { get; set; }
    }
}
