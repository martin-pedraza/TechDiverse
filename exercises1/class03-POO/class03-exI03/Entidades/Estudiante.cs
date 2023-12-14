using System;
using System.Text;

namespace Entidades
{
    public class Estudiante
    {
        private string apellido;
        private string legajo;
        private string nombre;
        private int notaPrimerParcial;
        private int notaSegundoParcial;
        private static Random random;

        static Estudiante()
        {
            random = new Random();
        }

        public Estudiante(string apellido, string legajo, string nombre)
        {
            this.apellido = apellido;
            this.legajo = legajo;
            this.nombre = nombre;
        }

        public int SetNotaPrimerParcial { set { this.notaPrimerParcial = value; } }
        public int SetNotaSegundoParcial { set { this.notaSegundoParcial = value; } }

        private float CalcularPromedio()
        {
            return ((float)this.notaPrimerParcial + (float)this.notaSegundoParcial) / 2;
        }

        public double CalcularNotaFinal()
        {
            return this.notaPrimerParcial >= 4 && this.notaSegundoParcial >= 4 ? random.Next(6, 11) : -1;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}   Apellido: {this.apellido}   Legajo: {this.legajo}");
            sb.AppendLine($"Primer parcial: {this.notaPrimerParcial}    Segundo parcial: {this.notaSegundoParcial}");
            sb.AppendLine($"Promedio: {this.CalcularPromedio()}");
            sb.AppendLine(this.VerificarAprobacion());
            return sb.ToString();
        }

        private string VerificarAprobacion()
        {
            double notaFinal = this.CalcularNotaFinal();
            return notaFinal != -1 ? $"Nota final: {notaFinal}" : "Alumno desaprobado"; 
        }
    }
}
