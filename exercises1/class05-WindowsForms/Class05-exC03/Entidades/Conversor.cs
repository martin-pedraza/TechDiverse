using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Conversor
    {
        public static string ConvertirDecimalABinario(int numeroEntero) {
            string binarioAlReves = "";
            string binarioOrdenado = "";
            while (numeroEntero > 0)
            {
                if (numeroEntero % 2 == 0)
                {
                    binarioAlReves += "0";
                }
                else
                {
                    binarioAlReves += "1";
                    numeroEntero--;
                }
                numeroEntero /= 2;
            }
            for (int i = binarioAlReves.Length; i > 0; i--)
            {
                binarioOrdenado += binarioAlReves[i - 1];
            }
            return binarioOrdenado;
        }

        public static int ConvertirBinarioADecimal(int numeroEntero) {
            string stringBinarioAlreves = numeroEntero.ToString();
            string binarioOrdenado = "";
            int numeroDecimal = 0;
            for (int i = stringBinarioAlreves.Length; i > 0; i--)
            {
                binarioOrdenado += stringBinarioAlreves[i - 1];
            }
            for (int i = 0; i < binarioOrdenado.Length; i++)
            {
                if (binarioOrdenado[i] == '0')
                {
                    continue;
                }
                else if (binarioOrdenado[i] == '1')
                {
                    numeroDecimal += (int)Math.Pow(2, i);
                }
                else
                {
                    numeroDecimal = -1;
                }
            }
            return numeroDecimal;
        }
    }
}
