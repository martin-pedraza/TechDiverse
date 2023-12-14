using System;
using Entidades;

namespace class04_exC01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumeroBinario objBinario = "10010";
            NumeroDecimal objDecimal = 8;

            Console.WriteLine(objDecimal + objBinario);
            Console.WriteLine(objBinario + objDecimal);

            string binario = (string)objBinario;
            double numeroDecimal = (double)objDecimal;

            Console.WriteLine(objBinario - (NumeroDecimal)numeroDecimal);
        }
    }
}
