using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TurismoF.Modelos.Observer
{
    // Observer
    public interface IObserver
    {
        void Update(string mensaje);
    }

    // Subject
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string mensaje);
    }

    // Reserva como sujeto que notifica cambios
    public partial class Reserva:ISubject
    {
        private List<IObserver> _observers = new();

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        public void Notify(string mensaje)
        {
            foreach(var obs in _observers)
                obs.Update(mensaje);
        }

        public void CambiarEstado(EstadoReserva nuevoEstado)
        {
            // ... lógica de cambio ...
            Notify($"Su reserva cambió a: {nuevoEstado}");
        }
    }

    // Cliente como observador
    public class Cliente:IObserver
    {
        public string Email { get; set; }
        public void Update(string mensaje)
        {
            // Aquí podrías enviar una notificación real (email, push, etc.)
            Console.WriteLine($"Notificando a {Email}: {mensaje}");
        }
    }
}
