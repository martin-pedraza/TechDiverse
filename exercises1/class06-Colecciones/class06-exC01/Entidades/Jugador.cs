using System;
using System.Text;

namespace Entidades
{
    public class Jugador
    {
        private int dni;
        private string nombre;
        private int partidosJugados;
        private float promedioGoles;
        private int totalGoles;
        private Jugador()
        {
            this.partidosJugados = 0;
            this.promedioGoles = 0;
            this.totalGoles = 0;
        }

        public Jugador(int dni, string nombre) :this()
        {
            this.dni = dni;
            this.nombre = nombre;
        }

        public Jugador(int dni, string nombre, int partidosJugados, int totalGoles) :this(dni, nombre)
        {
            this.partidosJugados = partidosJugados;
            this.totalGoles = totalGoles;
        }

        public float GetPromedioGoles()
        {
            return (float)this.totalGoles / this.partidosJugados;
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Jugador {this.nombre} - {this.dni}");
            sb.AppendLine($"Goles: {this.totalGoles}    Partidos: {this.partidosJugados}    Promedio: {this.GetPromedioGoles()}");
            return sb.ToString();
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            return j1.dni == j2.dni;
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

    }
}
