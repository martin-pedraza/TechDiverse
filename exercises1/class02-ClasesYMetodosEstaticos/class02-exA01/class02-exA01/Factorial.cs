using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exA01
{
    public static class Factorial
    {
        public static int Calcular(int numero)
        {
            int sumadorResultados = 1;
            for (int i = 1; i <= numero; i++)
            {
                sumadorResultados *= i;
            }
            return sumadorResultados;
        }
    }
}
