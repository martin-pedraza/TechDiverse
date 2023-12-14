using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exI07
{
    public static class TeoremaPitagoras
    {
        public static double CalcularHipotenusa(double primerCateto, double segundoCateto)
        {
            return Math.Sqrt(Math.Pow(primerCateto, 2) + Math.Pow(segundoCateto, 2));
        }
    }
}
