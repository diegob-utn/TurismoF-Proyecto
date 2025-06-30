using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using TurismoF.Modelos;

namespace TurismoF.Modelos.Factory
{
    public class TrenCompletoFactory
    {
        /// <summary>
        /// Crea un tren completo con vagones diferenciados, asientos numerados tipo cine y boletos para cada asiento.
        /// </summary>
        /// <param name="nombre">Nombre del tren</param>
        /// <param name="estado">Estado del tren</param>
        /// <param name="cantidadVagones">Total de vagones</param>
        /// <param name="cantidadVagonesPreferenciales">Cantidad de vagones preferenciales (el resto serán económicos)</param>
        /// <param name="filasPorVagon">Cantidad de filas por vagón</param>
        /// <param name="asientosPorFila">Cantidad de asientos por fila</param>
        /// <returns>Tren con toda la estructura generada</returns>
        public static Tren CrearTrenCompleto(
            string nombre,
            EstadoTren estado,
            int cantidadVagones,
            int cantidadVagonesPreferenciales,
            int filasPorVagon,
            int asientosPorFila)
        {
            var tren = new Tren
            {
                Nombre = nombre,
                Estado = estado,
                CantidadVagones = cantidadVagones,
                CantidadAsientosPorVagon = filasPorVagon * asientosPorFila,
                Vagones = new List<Vagon>()
            };

            int asientoIdSeed = 1;

            for(int i = 1; i <= cantidadVagones; i++)
            {
                var tipoVagon = i <= cantidadVagonesPreferenciales
                    ? TipoVagon.Preferencial
                    : TipoVagon.Economico;

                var vagon = new Vagon
                {
                    Numero = i,
                    TipoVagon = tipoVagon,
                    Tren = tren,
                    Asientos = new List<Asiento>()
                };

                for(int f = 0; f < filasPorVagon; f++)
                {
                    string letraFila = ((char)('A' + f)).ToString();
                    for(int n = 1; n <= asientosPorFila; n++)
                    {
                        var asiento = new Asiento
                        {
                            Id = asientoIdSeed++,
                            Codigo = $"V{i}{letraFila}{n}",
                            TipoAsiento = tipoVagon == TipoVagon.Preferencial ? TipoAsiento.Preferencial : TipoAsiento.Economico,
                            Fila = letraFila,
                            Numero = n,
                            Vagon = vagon,
                            VagonId = 0, // Setear correctamente al persistir
                            Boletos = new List<Boleto>()
                        };

                        // Crear boleto base (sin usuario, solo para inventario)
                        var boleto = new Boleto
                        {
                            // Id se asigna por la BD o repositorio
                            Asiento = asiento,
                            AsientoId = asiento.Id,
                            Estado = EstadoBoleto.Disponible,
                            TipoAsiento = asiento.TipoAsiento,
                            Categoria = CategoriaPasajero.SinAsignar
                            // Se pueden agregar más campos como Viaje, Precio, etc.
                        };
                        asiento.Boletos.Add(boleto);
                        vagon.Asientos.Add(asiento);
                    }
                }
                tren.Vagones.Add(vagon);
            }

            return tren;
        }
    }
}
