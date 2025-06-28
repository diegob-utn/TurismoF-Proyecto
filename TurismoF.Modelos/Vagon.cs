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
        public string Nombre { get; set; }
        public TipoVagon TipoVagon { get; set; }
        public int TrenId { get; set; }

        // No necesarios para ingresar desde Swagger
        public Tren Tren { get; set; }
        public List<Asiento> Asientos { get; set; }
    }
}
}
