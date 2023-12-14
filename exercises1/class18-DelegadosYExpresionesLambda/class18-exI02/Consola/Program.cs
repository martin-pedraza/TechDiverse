using System;
using System.Collections.Generic;
using static System.Environment;

namespace Consola
{
    class Program
    {
        public delegate int DelegadoComparacion(string primerTexto, string segundoTexto);

        static void Main(string[] args)
        {
            // Borrar o agregar la primera barra para switchear entre las pruebas fijas y el ingreso de texto por consola. 
            //*
            string primerTexto = "Vive como si fueras a morir mañana; aprende como si el mundo fuera a durar para siempre.";
            // Cant. caracteres: 88, Cant. palabras: 17 , Cant. vocales: 34, Cant. signos puntuación: 2 
            string segundoTexto = "La vida es como montar en bicicleta; para mantener el equilibrio debes seguir moviéndote.";
            // Cant. caracteres: 89, Cant. palabras: 13, Cant. vocales: 35, Cant. signos puntuación: 2

            /*/
            Console.WriteLine("Ingrese el primer texto:");
            string primerTexto = Console.ReadLine();

            Console.WriteLine("Ingrese el segundo texto:");
            string segundoTexto = Console.ReadLine();
            //*/

            int resultado = Comparar(primerTexto, segundoTexto, (t1, t2) => t1.Length - t2.Length);
            Console.WriteLine($"{NewLine}1era Comparación - Texto con más caracteres: {(resultado == -1 ? "Segundo texto" : "Primer texto")}");
            // Punto 2

            resultado = Comparar(primerTexto, segundoTexto, (t1, t2) => t1.Split(' ').Length - t2.Split(' ').Length);
            Console.WriteLine($"{NewLine}2da Comparación - Texto con más palabras: {(resultado == -1 ? "Segundo texto" : "Primer texto")}");
            // Punto 3
            
            resultado = Comparar(primerTexto, segundoTexto, (t1, t2) => ContarVocales(t1) - ContarVocales(t2));
            Console.WriteLine($"{NewLine}3era Comparación - Texto con más vocales: {(resultado == -1 ? "Segundo texto" : "Primer texto")}");
            // Punto 4

            resultado = Comparar(primerTexto, segundoTexto, (t1, t2) => ContarSignosPuntuacion(t1) - ContarSignosPuntuacion(t2));
            Console.WriteLine($"{NewLine}4ta Comparación - Texto con más signos de puntuación: {(resultado == -1 ? "Segundo texto" : "Primer texto")}");
            // Punto 5
        }

        public static int ContarVocales(string texto)
        {
            List<char> vocales = new List<char>()
            {
                'a', 'á', 'A', 'Á', 'e', 'é', 'E', 'É',
                'i', 'í', 'I', 'Í', 'o', 'ó', 'O', 'Ó',
                'u', 'ú', 'U', 'Ú'
            };

            return ContarCaracteres(texto, vocales);
        }

        public static int ContarSignosPuntuacion(string texto)
        {
            List<char> signosPuntuacion = new List<char>()
            {
                '.', ';', ','
            };

            return ContarCaracteres(texto, signosPuntuacion);
        }

        public static int ContarCaracteres(string texto, List<char> caracteres)
        {
            int cantidadCaracteres = 0;

            foreach (char caracter in texto)
            {
                if (caracteres.Contains(caracter))
                {
                    cantidadCaracteres++;
                }
            }

            return cantidadCaracteres;
        }

        public static int Comparar(string t1, string t2, DelegadoComparacion delegado)
        {
            return delegado(t1, t2);
        }
    }
}
