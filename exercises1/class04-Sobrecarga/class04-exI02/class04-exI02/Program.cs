using System;
using Billetes;

namespace class04_exI02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dolar d1 = new Dolar(400);
            Peso p1 = new Peso(120000, 300);
            Euro e1 = new Euro(200);

            Console.WriteLine(((Peso)d1).GetCantidad());
            Console.WriteLine(d1 == p1);
            Console.WriteLine((e1 + p1).GetCantidad());
        }
    }
}
