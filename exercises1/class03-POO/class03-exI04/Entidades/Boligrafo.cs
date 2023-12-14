using System;

namespace Entidades
{
    public class Boligrafo
    {
        public const short cantidadTintaMaxima = 100;
        private ConsoleColor color;
        private short tinta;

        public Boligrafo(ConsoleColor color, short tinta)
        {
            this.color = color;
            this.tinta = tinta;
        }

        public ConsoleColor Color { get { return this.color; }}
        public short Tinta { get { return this.tinta; }}

        private void SetTinta(short tinta)
        {
            if (this.Tinta + tinta < cantidadTintaMaxima && this.Tinta + tinta > 0)
            {
                this.tinta += tinta;
            }
        }

        public void Recargar()
        {
            this.SetTinta((short)(cantidadTintaMaxima - this.Tinta));
        }

        public bool Pintar(short gasto, out string dibujo)
        {
            if (this.Tinta > gasto)
            {
                dibujo = this.CrearDibujo(gasto);
                this.SetTinta(gasto);
            }
            else 
            {
                dibujo = this.CrearDibujo(this.Tinta);
                this.SetTinta(this.Tinta);
            }
            return true;
        }

        private string CrearDibujo(int cantidad)
        {
            string dibujo = "";
            for (int i = 0; i < cantidad; i++)
            {
                dibujo += "*";
            }
            return dibujo;
        }
    }
}
