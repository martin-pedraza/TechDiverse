using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NumeroDecimal
    {
        public double numero;
        private NumeroDecimal(double numero)
        {
            this.numero = numero;
        }
        public static implicit operator NumeroDecimal(double d)
        {
            return new NumeroDecimal(d);
        }
        public static explicit operator double(NumeroDecimal d)
        {
            return d.numero;
        }
        public static double operator +(NumeroDecimal d, NumeroBinario b)
        {
            return d.numero + b.ConvertirADecimal();
        }
        public static double operator -(NumeroDecimal d, NumeroBinario b)
        {
            return d.numero - b.ConvertirADecimal();
        }
        public static bool operator ==(NumeroDecimal d, NumeroBinario b)
        {
            return d.numero == b.ConvertirADecimal();
        }
        public static bool operator !=(NumeroDecimal d, NumeroBinario b)
        {
            return !(d == b);
        }

    }
}
