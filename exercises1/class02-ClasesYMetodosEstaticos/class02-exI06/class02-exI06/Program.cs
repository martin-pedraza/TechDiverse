using System;

namespace class02_exI06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ladoCuadrado;
            double baseTriangulo;
            double alturaTriangulo;
            double radioCirculo;
            do
            {
                Console.WriteLine("Ingrese la longitud del lado del cuadrado: ");
            } while (!double.TryParse(Console.ReadLine(), out ladoCuadrado));

            Console.WriteLine($"La area del cuadrado es: {CalculadoraDeArea.CalcularAreaCuadrado(ladoCuadrado)}");

            do
            {
                Console.WriteLine("Ingrese la longitud de la base del triangulo: ");
            } while (!double.TryParse(Console.ReadLine(), out baseTriangulo));

            do
            {
                Console.WriteLine("Ingrese la longitud de la altura del triangulo: ");
            } while (!double.TryParse(Console.ReadLine(), out alturaTriangulo));

            Console.WriteLine($"La area del triangulo es: {CalculadoraDeArea.CalcularAreaTriangulo(baseTriangulo, alturaTriangulo)}");

            do
            {
                Console.WriteLine("Ingrese la longitud del radio del circulo: ");
            } while (!double.TryParse(Console.ReadLine(), out radioCirculo));

            Console.WriteLine($"La area del circulo es: {CalculadoraDeArea.CalcularAreaCirculo(radioCirculo)}");
        }
    }
}
