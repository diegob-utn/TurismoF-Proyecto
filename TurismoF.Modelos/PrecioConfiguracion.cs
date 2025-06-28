using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class PrecioConfiguracion
    {
        // Necesarios
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        public decimal FactorCategoria { get; set; }
        public decimal FactorAsiento { get; set; }
        public DateTime FechaVigencia { get; set; }
        public int RutaId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Ruta Ruta { get; set; }
    }
}
