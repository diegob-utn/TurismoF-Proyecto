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
        public string Codigo { get; set; } // Ej: "A1"
        public TipoAsiento TipoAsiento { get; set; } // Preferencial/Economico

        // Nueva lógica: Guarda el número del vagón para trazabilidad
        public int NumeroVagon { get; set; }

        // FKs
        public int VagonId { get; set; }

        // Navegadores
        public Vagon? Vagon { get; set; }
        public List<Boleto>? Boletos { get; set; }
    }
}
