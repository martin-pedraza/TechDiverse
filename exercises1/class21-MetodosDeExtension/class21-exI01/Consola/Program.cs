using Biblioteca;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Today;
            Console.WriteLine(now.ObtenerPlacaCronicaTV(Estaciones.invierno));
            Console.WriteLine(now.ObtenerPlacaCronicaTV(Estaciones.primavera));
            Console.WriteLine(now.ObtenerPlacaCronicaTV(Estaciones.verano));
            Console.WriteLine(now.ObtenerPlacaCronicaTV(Estaciones.otonio));
        }
    }
}