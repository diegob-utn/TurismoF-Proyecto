using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public enum Categoria
    {
        Niño = 0,
        Adulto = 1,
        TerceraEdad = 2
    }

    public enum TipoAsiento
    {
        Preferencial = 0,
        Economico = 1
    }

    public enum TipoVagon
    {
        Preferencial = 0,
        Economico = 1
    }

    public enum EstadoReserva
    {
        Activa = 0,
        Cancelada = 1
    }

    public enum EstadoPago
    {
        Registrado = 0
    }

    public enum EstadoViaje
    {
        Programado = 0,
        Finalizado = 1,
        Cancelado = 2
    }

    public enum EstadoTren
    {
        Activo = 0,
        Inactivo = 1
    }
}
