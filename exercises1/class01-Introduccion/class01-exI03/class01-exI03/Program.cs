using System;

namespace class01_exI03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado;
            string contenidoIngresadoPorNumero;
            bool validarNumeroIngresado;
            string palabraTerminarIteracion = "salir";
            string contenidoIngresadoVolverOperar;
            string palabraPararOperar = "no";
            bool esPrimo = true;
            do
            {
                Console.WriteLine("Ingrese un numero o salir: ");
                contenidoIngresadoPorNumero = Console.ReadLine().ToLower();
                if (contenidoIngresadoPorNumero == palabraTerminarIteracion)
                {
                    break;
                }

                validarNumeroIngresado = int.TryParse(contenidoIngresadoPorNumero, out numeroIngresado);
                if (validarNumeroIngresado)
                {
                    Console.WriteLine($"Numeros primos hasta {numeroIngresado}");
                    for (int i = 2; i < numeroIngresado; i++)
                    {
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0 && i != j)
                            {
                                esPrimo = false;
                                break;
                            }
                        }
                        if (esPrimo)
                        {
                            Console.WriteLine(i);
                        }
                        esPrimo = true;
                    }
                }

                Console.WriteLine("Desea volver a operar? si / no ");
                contenidoIngresadoVolverOperar = Console.ReadLine().ToLower();

            } while (contenidoIngresadoVolverOperar != palabraPararOperar);
        }
    }
}
