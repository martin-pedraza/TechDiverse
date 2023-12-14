using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exI06
{
    public static class CalculadoraDeArea
    {
        public static double CalcularAreaCuadrado(double longitudLado) {
            return Math.Pow(longitudLado, 2);
        }

        public static double CalcularAreaTriangulo(double baseTriangulo, double altura) {
            return (baseTriangulo * altura) / 2;
        }

        public static double CalcularAreaCirculo(double radio) {
            return Math.PI * Math.Pow(radio, 2);
        }
    }
}
