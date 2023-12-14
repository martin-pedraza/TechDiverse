using System;
using Entidades;

namespace Entidades
{
    public class Sumador
    {
        public int cantidadSumas;

        public Sumador(int cantidadSumas)
        {
            this.cantidadSumas = cantidadSumas;
        }

        public Sumador() :this(0)
        {

        }

        public long Sumar(long a, long b)
        {
            return a + b;
        }

        public string Sumar(string a, string b)
        {
            return a + b;
        }

        public static explicit operator int(Sumador s)
        {
            return s.cantidadSumas;
        }

        public static long operator +(Sumador s1, Sumador s2)
        {
            return s1.cantidadSumas + s2.cantidadSumas;
        }

        public static bool operator |(Sumador s1, Sumador s2)
        {
            return s1.cantidadSumas == s2.cantidadSumas;
        }

    }
}
