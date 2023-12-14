using System;

namespace Entidades
{
    public class Celsius
    {
        private float temp;
        public Celsius(float temp)
        {
            this.temp = temp;
        }
        public float Temp
        {
            get { return this.temp; }
        }
        public static explicit operator Celsius(float f)
        {
            return new Celsius(f);
        }
        public static implicit operator float(Celsius c)
        {
            return c.Temp;
        }
        public static float operator -(Celsius c, Fahrenheit f)
        {
            return c - Conversor.ConvertirFaC(f);
        }
        public static float operator -(Celsius c, Kelvin k)
        {
            return c - Conversor.ConvertirKaC(k);
        }
    }
}
