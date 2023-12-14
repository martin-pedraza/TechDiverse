using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Biblioteca
    {
        private int codigoJuego;
        private string genero;
        private string juego;
        private string usuario;

        public Biblioteca(int codigoJuego, string genero, string juego, string usuario)
        {
            this.codigoJuego = codigoJuego;
            this.genero = genero;
            this.juego = juego;
            this.usuario = usuario;
        }

        public int CodigoJuego { get => codigoJuego; }
        public string Genero { get => genero; }
        public string Juego { get => juego; }
        public string Usuario { get => usuario; }
    }
}
