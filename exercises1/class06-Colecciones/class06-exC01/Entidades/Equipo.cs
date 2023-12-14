using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private short cantidadDeJugadores;
        List<Jugador> jugadores;
        private string nombre;
        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(short cantidadDeJugadores, string nombre) :this()
        {
            this.cantidadDeJugadores = cantidadDeJugadores;
            this.nombre = nombre;
        }

        public static bool operator +(Equipo e, Jugador j)
        {
            if ( (!e.jugadores.Contains(j)) && e.jugadores.Count < e.cantidadDeJugadores)
            {
                e.jugadores.Add(j);
                return true;
            }
            return false;
        }
    }
}
