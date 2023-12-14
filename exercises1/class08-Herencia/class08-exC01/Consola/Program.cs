using Entidades;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Equipo equipo = new Equipo(4, "utn");
            Jugador j1 = new Jugador(123, "nom1", 5, 20);
            Jugador j2 = new Jugador(485, "nom2", 3, 5);
            Jugador j3 = new Jugador(123, "nom3", 7, 3);
            Jugador j4 = new Jugador(789, "nom4", 3, 5);

            DirectorTecnico dt1 = new DirectorTecnico("Pepe", new DateTime(1993, 9, 21));
            DirectorTecnico dt2 = new DirectorTecnico("Jose", new DateTime(1990, 3, 17));
            DirectorTecnico dt3 = new DirectorTecnico("Pepe", new DateTime(1993, 9, 21));

            if (equipo + j1)
                Console.WriteLine(j1.MostrarDatos());

            Console.WriteLine("--------------------");

            if (equipo + j2)
                Console.WriteLine(j2.MostrarDatos());

            Console.WriteLine("--------------------");

            if (equipo + j3)
                Console.WriteLine(j3.MostrarDatos());
            else
                Console.WriteLine("NO SE AGREGO " + j3.MostrarDatos());

            Console.WriteLine("--------------------");

            if (equipo + j4)
                Console.WriteLine(j4.MostrarDatos());
            else
                Console.WriteLine("NO SE AGREGO " + j4.MostrarDatos());

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            Console.WriteLine("DT1: " + dt1.MostrarDatos());

            Console.WriteLine("--------------------");

            Console.WriteLine("DT2: " + dt2.MostrarDatos());

            Console.WriteLine("--------------------");

            Console.WriteLine("DT3: " + dt3.MostrarDatos());

            Console.WriteLine("--------------------");

            Console.WriteLine($"DT1 == DT2? {dt1==dt2}");
            Console.WriteLine($"DT1 == DT3? {dt1==dt3}");
        }
    }
}