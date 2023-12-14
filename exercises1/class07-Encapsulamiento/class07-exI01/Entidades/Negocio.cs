using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        public Negocio(string nombre) : this()
        {
            this.nombre = nombre;
        }

        private Negocio()
        {
            clientes = new Queue<Cliente>();
            caja = new PuestoAtencion(PuestoAtencion.Puesto.Caja1);
        }

        public Cliente Cliente
        {
            get
            {
                return clientes.Peek();
            }
            set
            {
                if (!clientes.Contains(value))
                {
                    clientes.Enqueue(value);
                }
            }
        }

        public int ClientesPendientes
        {
            get { return clientes.Count; }
        }

        public static bool operator ==(Negocio n, Cliente c)
        {
            return n.clientes.Contains(c);
        }
        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }
        public static bool operator +(Negocio n, Cliente c)
        {
            if (n != c)
            {
                n.clientes.Enqueue(c);
                return true;
            }
            return false;
        }
        public static bool operator ~(Negocio n)
        {
            if (n.ClientesPendientes > 0)
            {
                return n.caja.Atender(n.clientes.Dequeue());
            }
            return false;
        }
    }
}
