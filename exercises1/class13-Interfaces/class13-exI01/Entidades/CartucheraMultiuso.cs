using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CartucheraMultiuso
    {
        private List<IAcciones> acciones;

        public CartucheraMultiuso()
        {
            acciones = new List<IAcciones>();
        }

        public List<IAcciones> Acciones { get => acciones; }

        public bool RecorrerElementos()
        {
            bool retorno = true;
            foreach (IAcciones item in Acciones)
            {
                item.UnidadesDeEscritura -= 1;
                if (item.UnidadesDeEscritura < 0)
                {
                    item.UnidadesDeEscritura = 20;
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}
