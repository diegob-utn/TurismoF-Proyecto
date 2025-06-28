using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Vagon
    {
        // Necesarios
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoVagon TipoVagon { get; set; } // Preferencial/Economico

        // FKs
        public int TrenId { get; set; }

        // Navegadores
        public Tren? Tren { get; set; }
        public List<Asiento>? Asientos { get; set; }
    }
}
