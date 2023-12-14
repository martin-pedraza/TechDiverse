using System;

namespace class02_I03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int decimalIngresado;
            int binarioIngresado;
            int resultadoConversionBinario;
            do
            {
                Console.WriteLine("Ingrese un numero decimal: ");
            } while (!int.TryParse(Console.ReadLine(), out decimalIngresado));

            Console.WriteLine($"{decimalIngresado} a binario: {Conversor.ConvertirDecimalABinario(decimalIngresado)}");

            do
            {
                Console.WriteLine("Ingrese un numero binario: ");
            } while (!int.TryParse(Console.ReadLine(), out binarioIngresado));

            resultadoConversionBinario = Conversor.ConvertirBinarioADecimal(binarioIngresado);

            if (resultadoConversionBinario != -1)
            {
                Console.WriteLine($"{binarioIngresado} a decimal: {resultadoConversionBinario}");
            }
            else
            {
                Console.WriteLine("Numero no valido como binario");
            }
        }
    }
}
