using System;
using Geometria;

namespace class03_exI05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangulo r = new Rectangulo(new Punto(-2, -2), new Punto(6, 6));
            Console.WriteLine($"Area: {r.area}  Perimetro: {r.perimetro}");
        }
    }
}
