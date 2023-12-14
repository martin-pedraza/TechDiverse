using System;
using Entidades;

namespace class03_exI04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dibujo;
            Boligrafo azul = new Boligrafo(ConsoleColor.Blue, 3);
            Boligrafo rojo = new Boligrafo(ConsoleColor.Red, 5);

            Console.ForegroundColor = azul.Color;
            if (azul.Pintar(10, out dibujo))
            {
                Console.WriteLine(dibujo);
            }
            Console.ForegroundColor = rojo.Color;
            if (rojo.Pintar(2, out dibujo))
            {
                Console.WriteLine(dibujo);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
