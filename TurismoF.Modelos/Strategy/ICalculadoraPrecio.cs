using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurismoF.Modelos;
using System.Collections.Generic;

using TurismoF.Modelos;

namespace TurismoF.Modelos.Factory
{
    // Producto base
    public abstract class Boleto
    {
        public int Id { get; set; }
        public CategoriaPasajero Categoria { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        // ... otras propiedades ...
    }

    // Productos concretos
    public class BoletoEstandar:Boleto { }
    public class BoletoPreferencial:Boleto { }

    // Creador abstracto
    public abstract class BoletoFactory
    {
        public abstract Boleto CrearBoleto(CategoriaPasajero categoria, TipoAsiento tipoAsiento);
    }

    // Creadores concretos
    public class BoletoEstandarFactory:BoletoFactory
    {
        public override Boleto CrearBoleto(CategoriaPasajero categoria, TipoAsiento tipoAsiento)
        {
            return new BoletoEstandar
            {
                Categoria = categoria,
                TipoAsiento = tipoAsiento
            };
        }
    }

    public class BoletoPreferencialFactory:BoletoFactory
    {
        public override Boleto CrearBoleto(CategoriaPasajero categoria, TipoAsiento tipoAsiento)
        {
            return new BoletoPreferencial
            {
                Categoria = categoria,
                TipoAsiento = tipoAsiento
            };
        }
    }
}
