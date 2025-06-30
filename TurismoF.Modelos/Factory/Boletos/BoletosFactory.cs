using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TurismoF.Modelos.Factory.Boletos;

// Producto base
public abstract class Boleto
{
    public int Id { get; set; }
    public CategoriaPasajero Categoria { get; set; }
    public TipoAsiento TipoAsiento { get; set; }
    public int AsientoId { get; set; }
}

// Productos concretos
public class BoletoEstandar:Boleto { }
public class BoletoPreferencial:Boleto { }

// Factory para decidir el tipo de boleto automáticamente
public class BoletosFactory
{
    public static Boleto CrearBoleto(CategoriaPasajero categoria, Asiento asiento)
    {
        if(asiento.TipoAsiento == TipoAsiento.Preferencial)
        {
            return new BoletoPreferencial
            {
                Categoria = categoria,
                TipoAsiento = asiento.TipoAsiento,
                AsientoId = asiento.Id
            };
        }
        else
        {
            return new BoletoEstandar
            {
                Categoria = categoria,
                TipoAsiento = asiento.TipoAsiento,
                AsientoId = asiento.Id
            };
        }
    }

    // Generación en lote de boletos para todos los asientos de un tren
    public static List<Boleto> GenerarBoletosParaTren(Modelos.Tren tren, CategoriaPasajero categoria)
    {
        var boletos = new List<Boleto>();
        if(tren.Vagones == null) return boletos;
        foreach(var vagon in tren.Vagones)
        {
            if(vagon.Asientos == null) continue;
            foreach(var asiento in vagon.Asientos)
            {
                boletos.Add(CrearBoleto(categoria, asiento));
            }
        }
        return boletos;
    }
}