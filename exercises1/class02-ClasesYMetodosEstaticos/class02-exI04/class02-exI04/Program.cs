using System;

namespace class02_exI04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primerOperando;
            int segundoOperando;
            string operacion;
            double resultado;
            string respuesta = "s";

            while (respuesta == "s")
            {
                do
                {
                    Console.WriteLine("Ingrese el primer operando: ");
                } while (!int.TryParse(Console.ReadLine(), out primerOperando));

                do
                {
                    Console.WriteLine("Ingrese el segundo operando: ");
                } while (!int.TryParse(Console.ReadLine(), out segundoOperando));

                do
                {
                    Console.WriteLine("Ingrese la operacion matematica: ");
                    operacion = Console.ReadLine();
                } while (!(operacion == "+" || operacion == "-" || operacion == "*" || operacion == "/"));

                resultado = Calculadora.Calcular(primerOperando, segundoOperando, operacion);
                if (resultado != int.MinValue)
                {
                    Console.WriteLine($"{primerOperando} {operacion} {segundoOperando} = {resultado}");
                }
                else
                {
                    Console.WriteLine("Operacion no valida");
                }

                Console.WriteLine("Desea continuar? (s/n)");
                respuesta = Console.ReadLine().ToLower();
            }
        }
    }
}
