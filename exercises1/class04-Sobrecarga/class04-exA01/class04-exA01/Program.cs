using System;
using Entidades;

namespace class04_exA01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fahrenheit f = (Fahrenheit)83;
            Kelvin k = new Kelvin(100);
            Celsius c = (Celsius)Conversor.ConvertirFaC(f);

            Console.WriteLine(f == c);
            Console.WriteLine(c - f);
            Console.WriteLine(k + c);
        }
    }
}
