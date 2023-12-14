using System.Text.Json;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Persona() { }
        public Persona(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public static void Guardar(Persona p)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string completa = ruta + @"\"".xml";
            string completa = ruta + @"\personas.xml";
            using StreamWriter sr = new StreamWriter(completa);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Persona));
            xmlSerializer.Serialize(sr, p);
        }
        public static Persona Leer()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string completa = ruta + @"\"".xml";
            string completa = ruta + @"\personas.xml";

            using StreamReader sr = new StreamReader(completa);
            XmlSerializer xmlSerializer = new XmlSerializer (typeof(Persona));
            return xmlSerializer.Deserialize(sr) as Persona;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} Apellido: {Apellido}";
        }

        public static void GuardarJson(Persona persona)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string completa = ruta + @"\personas.json";

            using StreamWriter sr = new StreamWriter(completa);
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            string json = JsonSerializer.Serialize(persona, opciones);
            sr.Write(json);
        }

        public static Persona LeerJson()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string completa = ruta + @"\personas.json";

            using StreamReader sr = new StreamReader(completa);
            return JsonSerializer.Deserialize<Persona>(sr.ReadToEnd());
        }
    }
}