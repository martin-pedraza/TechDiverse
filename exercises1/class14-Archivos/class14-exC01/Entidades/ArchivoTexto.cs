using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ArchivoTexto
    {
        public static void Guardar(string ruta, string texto)
        {
			try
			{
				using StreamWriter sw = new StreamWriter(ruta);
				sw.WriteLine(texto);
			}
			catch (Exception)
			{
				throw new Exception("Error de archivo");
			}
        }

		public static string Leer(string ruta)
		{
			try
			{
				using StreamReader sr = new StreamReader(ruta);
				return sr.ReadToEnd();
			}
			catch (Exception)
			{
				throw new FileNotFoundException("Archivo no encontrado");
			}
		}
    }
}
