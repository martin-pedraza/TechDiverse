using System;

namespace class02_exI05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            do
            {
                Console.WriteLine("Ingrese un numero: ");
            } while (!int.TryParse(Console.ReadLine(), out numeroIngresado));
            Console.WriteLine(TablaMultiplicacion.ElaborarTabla(numeroIngresado));
        }
    }
}
