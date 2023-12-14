using Entidades;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor colorOriginal = Console.ForegroundColor;

            IAcciones miLapiz = new Lapiz(10);
            Boligrafo miBoligrafo = new Boligrafo(20, ConsoleColor.Green);

            EscrituraWrapper eLapiz = miLapiz.Escribir("Hola");
            Console.ForegroundColor = eLapiz.color;
            Console.WriteLine(eLapiz.texto);
            Console.ForegroundColor = colorOriginal;
            Console.WriteLine(miLapiz);

            EscrituraWrapper eBoligrafo = miBoligrafo.Escribir("Hola");
            Console.ForegroundColor = eBoligrafo.color;
            Console.WriteLine(eBoligrafo.texto);
            Console.ForegroundColor = colorOriginal;
            Console.WriteLine(miBoligrafo);

            CartucheraMultiuso multiuso = new CartucheraMultiuso();
            CartucheraSimple simple = new CartucheraSimple();

            multiuso.Acciones.Add(miLapiz);
            multiuso.Acciones.Add(miBoligrafo);

            simple.Lapices.Add((Lapiz)miLapiz);
            simple.Boligrafos.Add(miBoligrafo);

            Console.WriteLine(multiuso.RecorrerElementos()); 
            Console.WriteLine(simple.RecorrerElementos());
            Console.WriteLine(multiuso.RecorrerElementos());
            Console.WriteLine(simple.RecorrerElementos());
            Console.WriteLine(multiuso.RecorrerElementos());
            Console.WriteLine(simple.RecorrerElementos());
            Console.WriteLine(multiuso.RecorrerElementos());
            Console.WriteLine(simple.RecorrerElementos());
            Console.WriteLine(multiuso.RecorrerElementos());
            Console.WriteLine(simple.RecorrerElementos());

            Console.ReadKey();
        }
    }
}