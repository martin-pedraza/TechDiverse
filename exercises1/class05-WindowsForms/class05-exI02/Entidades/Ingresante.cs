using System.Text;

namespace Entidades
{
    public class Ingresante
    {
        private string[] cursos;
        private string direccion;
        private int edad;
        private string genero;
        private string nombre;
        private string pais;

        public Ingresante(string[] cursos, string direccion, int edad, string genero, string nombre, string pais)
        {
            this.cursos = cursos;
            this.direccion = direccion;
            this.edad = edad;
            this.genero = genero;
            this.nombre = nombre;
            this.pais = pais;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {nombre}");
            sb.AppendLine($"Direccion: {direccion}");
            sb.AppendLine($"Edad: {edad.ToString()}");
            sb.AppendLine($"Genero: {genero}");
            sb.AppendLine($"Pais: {pais}");
            sb.AppendLine("Curso/s:");
            foreach (string item in cursos)
            {
                if (item == "")
                {
                    continue;
                }
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
    }
}