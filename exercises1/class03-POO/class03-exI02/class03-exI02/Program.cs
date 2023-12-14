using System;
using Biblioteca;

namespace class03_exI02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Maria", DateTime.Parse("2020-05-05"), 30123123);
            Persona p2 = new Persona("Jose", DateTime.Parse("1980-05-05"), 30123123);
            Persona p3 = new Persona("Claudia", DateTime.Parse("2000-05-05"), 30123123);

            Console.WriteLine(p1.Mostrar() + " " + p1.EsMayorDeEdad());
            Console.WriteLine(p2.Mostrar() + " " + p2.EsMayorDeEdad());
            Console.WriteLine(p3.Mostrar() + " " + p3.EsMayorDeEdad());
           
            

        }
    }
}

