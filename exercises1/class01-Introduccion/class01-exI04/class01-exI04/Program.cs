using System;

namespace class01_exI04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumadorNumerosDivisores = 0;
            int cantidadNumeroPerfecto = 4;
            int cantidadIteracion = 0;
            int numeroAVerificar = 2;
            Console.WriteLine("Numeros perfectos: ");
            while (cantidadIteracion != cantidadNumeroPerfecto)
            {
                for (int i = 1; i < numeroAVerificar; i++)
                {
                    if (numeroAVerificar % i == 0 && numeroAVerificar != i)
                    {
                        sumadorNumerosDivisores += i;
                    }
                }
                if (numeroAVerificar == sumadorNumerosDivisores)
                {
                    Console.WriteLine(numeroAVerificar);
                    cantidadIteracion++;
                }
                sumadorNumerosDivisores = 0;
                numeroAVerificar++;
            }
        }
    }
}
