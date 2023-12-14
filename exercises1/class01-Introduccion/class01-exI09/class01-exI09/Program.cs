using System;

namespace class01_exI09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int alturaIngresada;
            string estrellaTriangulo = "*";
            string espacioPrevioTriangulo = " ";
            string sumadorStringFila;
            int espacioCentrarTriangulo = 10;

            do
            {
                Console.WriteLine("Ingrese la altura del triangulo: ");
            } while (!int.TryParse(Console.ReadLine(), out alturaIngresada));

            for (int i = 0; i < alturaIngresada; i++)
            {
                sumadorStringFila = "";
                for (int j = 0; j < espacioCentrarTriangulo - i; j++)
                {
                    sumadorStringFila += espacioPrevioTriangulo;
                }
                sumadorStringFila += estrellaTriangulo;
                estrellaTriangulo += "**";
                Console.WriteLine(sumadorStringFila);
            }
        }
    }
}
