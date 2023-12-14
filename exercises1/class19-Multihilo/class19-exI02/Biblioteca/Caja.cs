using System.Linq;

namespace Biblioteca
{
    public class Caja
    {
        public delegate void DelegadoClienteAtendido(Caja caja, string texto);

        private static Random random;
        private Queue<string> clientesALaEspera;
        private string nombreCaja;
        private DelegadoClienteAtendido delegadoClienteAtendido;

        static Caja()
        {
            random = new Random();
        }

        public string NombreCaja { get => nombreCaja; }
        public int CantidadDeClientesALaEspera { get => clientesALaEspera.Count; }

        public Caja(string nombreCaja, DelegadoClienteAtendido delegado)
        {
            clientesALaEspera = new Queue<string>();
            this.nombreCaja = nombreCaja;
            delegadoClienteAtendido = delegado;
        }

        internal void AgregarCliente(string cliente)
        {
            clientesALaEspera.Enqueue(cliente);
        }

        internal Task IniciarAtencion()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    if (clientesALaEspera.Any())
                    {
                        delegadoClienteAtendido(this, clientesALaEspera.Dequeue());
                        Thread.Sleep(random.Next(1000, 5000));
                    }
                }
            });
        }
    }
}