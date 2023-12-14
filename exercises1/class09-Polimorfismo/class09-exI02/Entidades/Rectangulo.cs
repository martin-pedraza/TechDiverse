using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rectangulo : Figura
    {
        private double ladoBase;
        private double ladoAltura;

        public Rectangulo(double ladoBase, double ladoAltura)
        {
            this.ladoBase = ladoBase;
            this.ladoAltura = ladoAltura;
        }

        public override double CalcularPerimetro()
        {
            return (ladoBase + ladoAltura) * 2;
        }

        public override double CalcularSuperficie()
        {
            return ladoAltura * ladoBase;
        }

        public override string Dibujar()
        {
            return "Dibujando rectangulo";
        }
    }
}
