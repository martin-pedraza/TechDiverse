using Biblioteca;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Torneo<EquipoBasquet> torneoBasquet = new Torneo<EquipoBasquet>("tBasquet");
            EquipoBasquet e1 = new EquipoBasquet("e1", DateTime.Now);
            EquipoBasquet e2 = new EquipoBasquet("e2", DateTime.Now);
            EquipoBasquet e3 = new EquipoBasquet("e3", DateTime.Now);
            Torneo<EquipoFutbol> torneoFutbol = new Torneo<EquipoFutbol>("tFutbol");
            EquipoFutbol e4 = new EquipoFutbol("e4", DateTime.Now);
            EquipoFutbol e5 = new EquipoFutbol("e5", DateTime.Now);
            EquipoFutbol e6 = new EquipoFutbol("e6", DateTime.Now);

            _ = torneoBasquet + e1;
            _ = torneoBasquet + e2;
            _ = torneoBasquet + e3;
            _ = torneoFutbol + e4;
            _ = torneoFutbol + e5;
            _ = torneoFutbol + e6;

            Console.WriteLine(torneoBasquet.Mostrar());
            Console.WriteLine(torneoFutbol.Mostrar());

            Console.WriteLine(torneoBasquet.JugarPartido);
            Console.WriteLine(torneoBasquet.JugarPartido);
            Console.WriteLine(torneoBasquet.JugarPartido);
            Console.WriteLine(torneoFutbol.JugarPartido);
            Console.WriteLine(torneoFutbol.JugarPartido);
            Console.WriteLine(torneoFutbol.JugarPartido);
        }
    }
}