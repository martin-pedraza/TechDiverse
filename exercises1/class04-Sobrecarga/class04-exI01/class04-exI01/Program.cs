using System;
using Entidades;

namespace class04_exI01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sumador sumador1 = new Sumador();
            Console.WriteLine(sumador1.Sumar(3, 5));

            Sumador sumador2 = new Sumador(2);
            Console.WriteLine((int)sumador2);
        }
    }
}
