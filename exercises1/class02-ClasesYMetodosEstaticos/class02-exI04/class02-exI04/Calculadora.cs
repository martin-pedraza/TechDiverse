using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exI04
{
    public static class Calculadora
    {
        public static double Calcular(int primerOperando, int segundoOperando, string operacion)
        {
            switch (operacion)
            {
                case "*":
                    return primerOperando * segundoOperando;
                case "+":
                    return primerOperando + segundoOperando;
                case "-":
                    return primerOperando - segundoOperando;
                case "/":
                    if (Validar(segundoOperando))
                    {
                        return primerOperando / segundoOperando;
                    }
                    return int.MinValue;
                default:
                    return int.MinValue;
            }
        }

        private static bool Validar(int segundoOperando)
        {
            return segundoOperando != 0;
        }
    }
}
