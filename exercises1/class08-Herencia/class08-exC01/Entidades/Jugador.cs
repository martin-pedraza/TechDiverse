using System;
using System.Text;

namespace Entidades
{
    public class Jugador : Persona
    {
        private int partidosJugados;
        private int totalGoles;

        public int PartidosJugados { get => partidosJugados; }
        public float PromedioGoles { get => (float)this.totalGoles / this.partidosJugados; }
        public int TotalGoles { get => totalGoles; }


        public Jugador(int dni, string nombre) : base(dni, nombre)
        {
            this.partidosJugados = 0;
            this.totalGoles = 0;
        }

        public Jugador(int dni, string nombre, int partidosJugados, int totalGoles) : this(dni, nombre)
        {
            this.partidosJugados = partidosJugados;
            this.totalGoles = totalGoles;
        }

        public override string MostrarDatos()
        {
            return $"{base.MostrarDatos()} \nPartidos: {PartidosJugados} Goles: {TotalGoles} Promedio: {PromedioGoles}"; 
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
