using System;

namespace class01_exI05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            int numeroAnterior;
            int numeroSiguiente;
            int sumadorNumerosAntes;
            int sumadorNumerosDespues;
            do
            {
                Console.WriteLine("Ingrese un numero: ");
            } while (!int.TryParse(Console.ReadLine(), out numeroIngresado));
            Console.WriteLine($"Centros numericos hasta el numero {numeroIngresado}:");
            for (int i = 2; i < numeroIngresado; i++)
            {
                sumadorNumerosAntes = 0;
                sumadorNumerosDespues = 0;
                for (numeroAnterior = 1; numeroAnterior < i; numeroAnterior++)
                {
                    sumadorNumerosAntes += numeroAnterior;
                }
                numeroSiguiente = i + 1;
                while (sumadorNumerosAntes > sumadorNumerosDespues)
                {
                    sumadorNumerosDespues += numeroSiguiente;
                    numeroSiguiente++;
                }
                if (sumadorNumerosAntes == sumadorNumerosDespues)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
