using System;
using System.Text;

namespace Entidades
{
    public class Jugador
    {
        private int dni;
        private string nombre;
        private int partidosJugados;
        private int totalGoles;

        public int PartidosJugados { get => partidosJugados; }
        public float PromedioGoles { get => (float)this.totalGoles / this.partidosJugados; }
        public int TotalGoles { get => totalGoles; }
        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        private Jugador()
        {
            this.partidosJugados = 0;
            this.totalGoles = 0;
        }

        public Jugador(int dni, string nombre) :this()
        {
            this.Dni = dni;
            this.Nombre = nombre;
        }

        public Jugador(int dni, string nombre, int partidosJugados, int totalGoles) :this(dni, nombre)
        {
            this.partidosJugados = partidosJugados;
            this.totalGoles = totalGoles;
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Jugador {this.Nombre} - {this.Dni}");
            sb.AppendLine($"Goles: {this.totalGoles}    Partidos: {this.partidosJugados}    Promedio: {this.PromedioGoles}");
            return sb.ToString();
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            return j1.Dni == j2.Dni;
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

    }
}
