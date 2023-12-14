using Biblioteca;
using System.IO;

namespace Biblioteca
{
    public class PuntoTxt : Archivo, IArchivo<string>
    {
        public override string Extension
        {
            get
            {
                return ".txt";
            }
        }

        public void Guardar(string ruta, string contenido)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtensión(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }

        public void GuardarComo(string ruta, string contenido)
        {
            if (ValidarExtensión(ruta))
            {
                GuardarArchivo(ruta, contenido);
            }
        }

        private void GuardarArchivo(string ruta, string contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.WriteLine(contenido);
            }
        }

        public string Leer(string ruta)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtensión(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    return streamReader.ReadToEnd();
                }
            }

            return string.Empty;
        }
    }
}