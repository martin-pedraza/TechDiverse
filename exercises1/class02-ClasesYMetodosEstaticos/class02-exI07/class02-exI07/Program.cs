using System;

namespace class02_exI07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double primerCateto;
            double segundoCateto;
            do
            {
                Console.WriteLine("Ingrese la longitud del primer cateto: ");
            } while (!double.TryParse(Console.ReadLine(), out primerCateto));

            do
            {
                Console.WriteLine("Ingrese la longitud del segundo cateto: ");
            } while (!double.TryParse(Console.ReadLine(), out segundoCateto));

            Console.WriteLine($"La hipotenusa mide {TeoremaPitagoras.CalcularHipotenusa(primerCateto, segundoCateto)}");
        }
    }
}
