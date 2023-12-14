using System;

namespace class02_exI01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantNumerosSolicitados = 2;
            int numeroIngresado;
            int menorNumeroIngresado = int.MaxValue;
            int mayorNumeroIngresado = int.MinValue;
            int sumadorNumerosIngresados = 0;
            double promedioNumerosIngresados;
            bool verificarNumeroIngresado;
            bool validarRango;
            for (int i = 0; i < cantNumerosSolicitados; i++)
            {
                do
                {
                    Console.WriteLine($"Ingrese un numero: [{i + 1}]");
                    verificarNumeroIngresado = !(int.TryParse(Console.ReadLine(), out numeroIngresado));
                    validarRango = !(Validador.Validar(numeroIngresado, -100, 100));
                } while (verificarNumeroIngresado || validarRango);

                
                sumadorNumerosIngresados += numeroIngresado;
                if (numeroIngresado > mayorNumeroIngresado)
                {
                    mayorNumeroIngresado = numeroIngresado;
                }
                if (numeroIngresado < menorNumeroIngresado)
                {
                    menorNumeroIngresado = numeroIngresado;
                }
            }
            promedioNumerosIngresados = (double)sumadorNumerosIngresados / cantNumerosSolicitados;

            Console.WriteLine($"Numero maximo: {mayorNumeroIngresado}");
            Console.WriteLine($"Numero minimo: {menorNumeroIngresado}");
            Console.WriteLine($"Promedio: {promedioNumerosIngresados}");
        }
    }
}
