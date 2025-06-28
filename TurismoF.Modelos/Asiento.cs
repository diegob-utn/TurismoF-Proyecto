using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Asiento
    {
        // Necesarios
        public int Id { get; set; }
        public string Codigo { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        public int VagonId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Vagon Vagon { get; set; }
        public List<Boleto> Boletos { get; set; }
    }
}
