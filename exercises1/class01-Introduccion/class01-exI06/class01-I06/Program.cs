using System;

namespace class01_I06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anioInicio;
            int anioFin;
            do
            {
                Console.WriteLine("Ingrese anio de inicio: ");
            } while (!int.TryParse(Console.ReadLine(), out anioInicio));
            do
            {
                Console.WriteLine("Ingrese anio de fin: ");
            } while (!int.TryParse(Console.ReadLine(), out anioFin));

            Console.WriteLine($"Años bisiestos entre {anioInicio} y {anioFin}:");

            for (int i = anioInicio; i < anioFin; i++)
            {
                if (i % 4 == 0 && (i % 100 != 0 || i % 400 == 0))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
