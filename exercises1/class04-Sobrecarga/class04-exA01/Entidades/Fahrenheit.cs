using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fahrenheit
    {
        private float temp;

        public Fahrenheit(float temp)
        {
            this.temp = temp;
        }

        public float Temp
        {
            get { return this.temp; }
        }
        public static explicit operator Fahrenheit(float f)
        {
            return new Fahrenheit(f);
        }
        public static implicit operator float(Fahrenheit f)
        {
            return f.Temp;
        }
        public static bool operator ==(Fahrenheit f, Kelvin k)
        {
            return f == Conversor.ConvertirKaF(k);
        }
        public static bool operator !=(Fahrenheit f, Kelvin k)
        {
            return !(f == k);
        }
        public static bool operator ==(Fahrenheit f, Celsius c)
        {
            return f == Conversor.ConvertirCaF(c);
        }
        public static bool operator !=(Fahrenheit f, Celsius c)
        {
            return !(f == c);
        }
    }
}
