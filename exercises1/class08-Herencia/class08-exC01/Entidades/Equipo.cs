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

        public Equipo(short cantidadDeJugadores, string nombre) : this()
        {
            this.cantidadDeJugadores = cantidadDeJugadores;
            this.nombre = nombre;
        }

        public static bool operator +(Equipo e, Jugador j)
        {
            bool faltaJugador = false;
            if (e.jugadores.Count < e.cantidadDeJugadores)
            {
                faltaJugador = true;
                foreach (Jugador item in e.jugadores)
                {
                    if (item == j)
                    {
                        faltaJugador = false;
                        break;
                    }
                }
            }
            if (faltaJugador)
            {
                e.jugadores.Add(j);

            }
            return faltaJugador;
        }
    }
}
