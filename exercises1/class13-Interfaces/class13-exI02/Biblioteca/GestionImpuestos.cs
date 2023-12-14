using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class GestionImpuestos
    {
        private List<IAduana> impuestosAduana;
        private List<IAfip> impuestosAfip;

        public GestionImpuestos()
        {
            impuestosAduana = new List<IAduana>();
            impuestosAfip = new List<IAfip>();
        }

        public decimal CalcularTotalImpuestosAduana()
        {
            decimal sumador = 0;
            foreach (IAduana item in impuestosAduana)
            {
                sumador += item.Impuestos;
            }
            return sumador;
        }

        public decimal CalcularTotalImpuestosAfip()
        {
            decimal sumador = 0;
            foreach (IAfip item in impuestosAfip)
            {
                sumador += ((IAfip)item).Impuestos;
            }
            return sumador;

        }

        public void RegistrarImpuestos(IEnumerable<Paquete> paquetes)
        {
            foreach (Paquete item in paquetes)
            {
                RegistrarImpuestos(item);
            }
        }

        public void RegistrarImpuestos(Paquete paquete)
        {
            impuestosAduana.Add(paquete);
            if (paquete is IAfip)
            {
                impuestosAfip.Add((IAfip)paquete);
            }
        }

    }
}
