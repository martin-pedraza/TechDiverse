using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class PuntoJson<T> : Archivo, IArchivo<T>
        where T : class
    {
        public override string Extension
        {
            get
            {
                return ".json";
            }
        }

        public void Guardar(string ruta, T contenido)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtensión(ruta))
            {
                using StreamWriter sr = new StreamWriter(ruta);
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                sr.Write(JsonSerializer.Serialize(contenido, options));
            }
        }

        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtensión(ruta))
            {
                using StreamWriter sr = new StreamWriter(ruta);
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                sr.Write(JsonSerializer.Serialize(contenido, options));
            }
        }

        public T Leer(string ruta)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtensión(ruta))
            {
                using StreamReader sr = new StreamReader(ruta);

                return JsonSerializer.Deserialize<T>(sr.ReadToEnd());
            }
            return null;
        }
    }
}
