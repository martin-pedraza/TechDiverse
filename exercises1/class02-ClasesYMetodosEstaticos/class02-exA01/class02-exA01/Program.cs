using System;

namespace class02_exA01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            do
            {
                Console.WriteLine("Ingrese un numero: ");
            } while (!int.TryParse(Console.ReadLine(), out numeroIngresado)
                        || numeroIngresado < 1);
            Console.WriteLine($"El factorial es {Factorial.Calcular(numeroIngresado)}");
        }
    }
}
