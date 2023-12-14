using System;

namespace class01_exI08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int alturaIngresada;
            string estrellaTriangulo = "*";
            do
            {
                Console.WriteLine("Ingrese altura del triangulo");
            } while (!int.TryParse(Console.ReadLine(), out alturaIngresada));
            for (int i = 0; i < alturaIngresada; i++)
            {
                Console.WriteLine(estrellaTriangulo);
                estrellaTriangulo += "**";
            }
        }
    }
}
