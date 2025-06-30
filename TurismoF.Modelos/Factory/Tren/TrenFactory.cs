using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TurismoF.Modelos.Factory.Tren
{
    public class TrenFactory
    {
        public Modelos.Tren CrearTren(string nombre, EstadoTren estado, int cantidadVagones, int cantidadAsientosPorVagon)
        {
            var tren = new Modelos.Tren
            {
                Nombre = nombre,
                Estado = estado,
                CantidadVagones = cantidadVagones,
                CantidadAsientosPorVagon = cantidadAsientosPorVagon,
                Vagones = new List<Vagon>()
            };

            for(int i = 1; i <= cantidadVagones; i++)
            {
                var tipoVagon = i == 1 ? TipoVagon.Preferencial : TipoVagon.Economico;
                var vagon = new Vagon
                {
                    Numero = i,
                    TipoVagon = tipoVagon,
                    Asientos = new List<Asiento>()
                };

                for(int j = 1; j <= cantidadAsientosPorVagon; j++)
                {
                    vagon.Asientos.Add(new Asiento
                    {
                        Codigo = $"V{i}A{j}",
                        TipoAsiento = tipoVagon == TipoVagon.Preferencial ? TipoAsiento.Preferencial : TipoAsiento.Economico
                    });
                }
                tren.Vagones.Add(vagon);
            }

            return tren;
        }
    }
}
