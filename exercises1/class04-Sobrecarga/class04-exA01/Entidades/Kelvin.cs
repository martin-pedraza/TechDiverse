using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Kelvin
    {
        private float temp;

        public Kelvin(float temp)
        {
            this.temp = temp;

        }
        public float Temp
        {
            get { return this.temp; }
        }
        public static explicit operator Kelvin(float f)
        {
            return new Kelvin(f);
        }
        public static implicit operator float(Kelvin k)
        {
            return k.Temp;
        }
        public static float operator +(Kelvin k, Fahrenheit f)
        {
            return k + Conversor.ConvertirFaK(f);
        }
        public static float operator +(Kelvin k, Celsius c)
        {
            return k + Conversor.ConvertirCaK(c);
        }
    }
}
