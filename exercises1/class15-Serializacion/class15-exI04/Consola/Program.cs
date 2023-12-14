using Biblioteca;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona("Laura", "Corrales");
            try
            {
                Persona.Guardar(p);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Ruta del archivo no valida");
            }
            try
            {
                Console.WriteLine(Persona.Leer().ToString());
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Ruta del archivo no valida");
            }
            Persona.GuardarJson(p);
            Console.WriteLine(Persona.LeerJson().ToString());
        }
    }
}