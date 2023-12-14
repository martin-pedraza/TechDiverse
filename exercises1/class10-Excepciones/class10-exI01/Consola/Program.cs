using Entidades;
using Entidades.Excepciones;
using Entidades.Modelos;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				OtraClase otraClase = new OtraClase();
			}
			catch (MiExcepcion e)
			{
                Console.WriteLine(e);
            }
        }
    }
}