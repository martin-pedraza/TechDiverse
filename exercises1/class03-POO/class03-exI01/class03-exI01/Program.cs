using System;
using Biblioteca;

namespace class03_exI01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal cantidadRetirada;
            decimal cantidadIngresada;
            Cuenta c1 = new Cuenta("Jorge", 120000);

            do
            {
                Console.WriteLine("Extraccion: ");
            } while (!decimal.TryParse(Console.ReadLine(), out cantidadRetirada));

            c1.Retirar(cantidadRetirada);
            
            do
            {
                Console.WriteLine("Deposito: ");
            } while (!decimal.TryParse(Console.ReadLine(), out cantidadIngresada));

            c1.Ingresar(cantidadIngresada);

            Console.WriteLine(c1.Mostrar());
        }
    }
}
