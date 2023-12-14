using System;

namespace class01_exI02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            double cuadradoNumeroIngresado;
            double cuboNumeroIngresado;
            bool validarNumeroIngresado;
            do
            {
                Console.WriteLine("Escribe un numero: ");
                validarNumeroIngresado = !int.TryParse(Console.ReadLine(), out numeroIngresado) || numeroIngresado < 0;
                if (validarNumeroIngresado)
                {
                    Console.WriteLine("ERROR. ¡Reingresar número!");
                }
            } while (validarNumeroIngresado);
            cuadradoNumeroIngresado = Math.Pow(numeroIngresado, 2);
            cuboNumeroIngresado = Math.Pow(numeroIngresado, 3);
            Console.WriteLine($"El numero ingresado fue {numeroIngresado}. Su cuadrado es {cuadradoNumeroIngresado} y su cubo es {cuboNumeroIngresado}");
        }
    }
}
