using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CompetenciaNoDisponibleException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;
        public CompetenciaNoDisponibleException(string message, string nombreClase, string nombreMetodo) : this(message, nombreClase, nombreMetodo, null)
        {
        }

        public CompetenciaNoDisponibleException(string message, string nombreClase, string nombreMetodo, Exception innerException) : base(message, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public string NombreClase { get => nombreClase; }
        public string NombreMetodo { get => nombreMetodo; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Excepción en el método {NombreMetodo} de la clase {NombreClase}:");
            sb.AppendLine(base.Message);
            sb.AppendLine(base.InnerException.Message);
            return sb.ToString();
        }
    }
}
