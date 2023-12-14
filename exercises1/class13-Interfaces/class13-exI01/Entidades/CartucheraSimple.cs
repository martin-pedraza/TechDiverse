using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CartucheraSimple
    {
        private List<Boligrafo> boligrafos;
        private List<Lapiz> lapices;

        public CartucheraSimple()
        {
            boligrafos = new List<Boligrafo>();
            lapices = new List<Lapiz>();
        }

        public List<Boligrafo> Boligrafos { get => boligrafos; }
        public List<Lapiz> Lapices { get => lapices; }

        public bool RecorrerElementos()
        {
            bool retorno = true;
            foreach (Boligrafo item in Boligrafos)
            {
                item.UnidadesDeEscritura -= 1;
                if (item.UnidadesDeEscritura < 0)
                {
                    item.UnidadesDeEscritura = 20;
                    retorno = false;
                }
            }
            foreach (Lapiz item in Lapices)
            {
                ((IAcciones)item).UnidadesDeEscritura -= 1;
                if (((IAcciones)item).UnidadesDeEscritura < 0)
                {
                    ((IAcciones)item).UnidadesDeEscritura = 20;
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}
