using System;
using Entidades;

namespace class03_exI03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante("Perez", "111000", "Marcelo");   
            Estudiante e2 = new Estudiante("Gomez", "111111", "Marta");   
            Estudiante e3 = new Estudiante("Molina", "111222", "Mariano");

            e1.SetNotaPrimerParcial = 7;
            e1.SetNotaSegundoParcial = 10;
            e2.SetNotaPrimerParcial = 3;
            e2.SetNotaSegundoParcial = 2;
            e3.SetNotaPrimerParcial = 6;
            e3.SetNotaSegundoParcial = 7;

            Console.WriteLine(e1.Mostrar());
            Console.WriteLine(e2.Mostrar());
            Console.WriteLine(e3.Mostrar());
        }
    }
}
