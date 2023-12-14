using System;

namespace class01_exI01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumadoNumeroIngresado = 0;
            int numeroIngresado;
            int numeroIteraciones = 5;
            int limiteMaximo = int.MinValue;
            int limiteMiinimo = int.MaxValue;
            for (int i = 1; i <= numeroIteraciones; i++)
            {
                do
                {
                    Console.WriteLine($"Ingrese un numero: [{i}]");
                } while (!int.TryParse(Console.ReadLine(), out numeroIngresado));
                if (numeroIngresado > limiteMaximo)
                {
                    limiteMaximo = numeroIngresado;
                }
                if (numeroIngresado < limiteMiinimo)
                {
                    limiteMiinimo = numeroIngresado;
                }
                sumadoNumeroIngresado += numeroIngresado;
            }
            Console.WriteLine($"Promedio de los numeros ingresados: {sumadoNumeroIngresado/numeroIteraciones}");
            Console.WriteLine($"Menor numero ingresado: {limiteMiinimo}");
            Console.WriteLine($"Mayor numero ingresado: {limiteMaximo}");
        }
    }
}
