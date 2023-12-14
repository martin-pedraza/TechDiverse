using System;
using Entidades;

namespace class03_exA02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente c1 = new Cliente("Juan", "Monroe", "Calle 123", "1122334455", new Mascota("Perro", "Pichichu", DateTime.Parse("2020-05-05")));
            Cliente c2 = new Cliente("Mario", "Garcia", "Avenida 234", "2233223322", new Mascota("Gato", "Michi", DateTime.Parse("2019-04-01"), "Triple Felina"));
            Cliente c3 = new Cliente("Sergio", "Aguero", "Pasaje 345", "3344331122", new Mascota("Perro", "Firulais", DateTime.Parse("2005-08-10"), "Rabia"));
            c3.AgregarMascota(new Mascota("Gato", "Steph", DateTime.Parse("2013-10-12")));

            Console.WriteLine(c1.Mostrar());
            Console.WriteLine(c2.Mostrar());
            Console.WriteLine(c3.Mostrar());
        }
    }
}
