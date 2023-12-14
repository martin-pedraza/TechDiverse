using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Circulo : Figura
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }

        public override double CalcularPerimetro()
        {
            return radio * 2 * Math.PI;
        }

        public override double CalcularSuperficie()
        {
            return Math.Pow(radio, 2) * Math.PI;
        }

        public override string Dibujar()
        {
            return "Dibujando circulo";
        }
    }
}
