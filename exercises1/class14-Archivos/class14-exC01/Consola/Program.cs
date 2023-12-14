using Entidades;
using Entidades.Excepciones;
using Entidades.Modelos;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = ruta + @$"\{DateTime.Now.ToString("yyyyMMdd-HHmm")}.txt";
            try
            {
                OtraClase otraClase = new OtraClase();
            }
            catch (MiExcepcion e)
            {
                ArchivoTexto.Guardar(rutaCompleta, e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(ArchivoTexto.Leer(rutaCompleta));
        }
    }
}