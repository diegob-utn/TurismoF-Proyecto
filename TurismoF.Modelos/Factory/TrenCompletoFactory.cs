using System;
using System.Collections.Generic;
using TurismoF.Modelos;

namespace TurismoF.Modelos.Factory
{
    public class TrenCompletoFactory
    {
        /// <summary>
        /// Crea un tren completo con numeración individual por tipo de asiento (ejemplo: v1, p1...).
        /// </summary>
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

                // Contadores por tipo
                int contadorVentana = 1;
                int contadorPasillo = 1;

                for(int f = 0; f < filasPorVagon; f++)
                {
                    string letraFila = ((char)('A' + f)).ToString();

                    for(int n = 1; n <= asientosPorFila; n++)
                    {
                        // Ejemplo: solo 2 tipos, ventana y pasillo (ajusta si tienes más)
                        TipoAsiento tipoAsiento;
                        string codigoAsiento;
                        string sufijoTipo;
                        int numeroIndividual;

                        // Puedes definir la lógica de qué número es ventana/pasillo según tu disposición
                        if(n == 1 || n == asientosPorFila) // Asientos en los extremos = ventana
                        {
                            tipoAsiento = TipoAsiento.Ventana;
                            sufijoTipo = "v";
                            numeroIndividual = contadorVentana++;
                        }
                        else // El resto = pasillo
                        {
                            tipoAsiento = TipoAsiento.Pasillo;
                            sufijoTipo = "p";
                            numeroIndividual = contadorPasillo++;
                        }

                        codigoAsiento = $"{sufijoTipo}{numeroIndividual}";

                        var asiento = new Asiento
                        {
                            Id = asientoIdSeed++,
                            Codigo = codigoAsiento,
                            TipoAsiento = tipoAsiento,
                            Fila = letraFila,
                            Numero = n,
                            Vagon = vagon,
                            VagonId = 0, // Setear correctamente al persistir
                            Boletos = new List<Boleto>()
                        };

                        // Crear boleto base (sin usuario, solo para inventario)
                        var boleto = new Boleto
                        {
                            Asiento = asiento,
                            AsientoId = asiento.Id,
                            Estado = EstadoBoleto.Disponible,
                            TipoAsiento = asiento.TipoAsiento,
                            Categoria = CategoriaPasajero.SinAsignar
                            // Otros campos...
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