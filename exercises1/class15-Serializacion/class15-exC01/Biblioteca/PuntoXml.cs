using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class PuntoXml<T> : Archivo, IArchivo<T>
        where T : class
    {
        public override string Extension
        {
            get
            {
                return ".xml";
            }
        }

        public void Guardar(string ruta, T contenido)
        {
            if (ValidarExtensión(ruta) && ValidarSiExisteElArchivo(ruta))
            {
                using StreamWriter sr = new StreamWriter(ruta);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sr, contenido);
            }
        }

        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtensión(ruta))
            {
                using StreamWriter sr = new StreamWriter(ruta);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sr, contenido);
            }
        }

        public T Leer(string ruta)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtensión(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return xmlSerializer.Deserialize(streamReader) as T;
                }
            }
            return null;
        }
    }
}
