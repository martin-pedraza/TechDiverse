using System;

namespace class02_exI02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            int sumadorNumerosIngresados = 0;
            string respuesta;
            do
            {
                do
                {
                    Console.WriteLine("Ingrese un numero: ");
                } while (!int.TryParse(Console.ReadLine(), out numeroIngresado));

                sumadorNumerosIngresados += numeroIngresado;
                Console.WriteLine("Desea continuar? (S/N)");
                respuesta = Console.ReadLine().ToLower();

            } while (Validador.ValidarRespuesta(respuesta));

            Console.WriteLine($"La suma de los numeros ingresados es: {sumadorNumerosIngresados}");
        }
    }
}
