using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lapiz : IAcciones
    {
        private ConsoleColor colorTinta;
        private float tamanioMina;

        public Lapiz(float tamanioMina)
        {
            ((IAcciones)this).UnidadesDeEscritura = tamanioMina;
            colorTinta = ConsoleColor.Gray;
        }

        ConsoleColor IAcciones.Color { get => colorTinta; set => throw new NotImplementedException(); }
        float IAcciones.UnidadesDeEscritura { get => tamanioMina; set => tamanioMina = value; }

        EscrituraWrapper IAcciones.Escribir(string texto)
        {
            float cantidad = ((IAcciones)this).UnidadesDeEscritura / 0.1f;
            if (cantidad >= texto.Length)
            {
                ((IAcciones)this).UnidadesDeEscritura -= texto.Length * 0.1f;
                return new EscrituraWrapper(texto, ((IAcciones)this).Color);
            }
            return new EscrituraWrapper( texto.Substring(0, (int)cantidad), ((IAcciones)this).Color);
        }

        bool IAcciones.Recargar(int unidades)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {((IAcciones)this).UnidadesDeEscritura} de color {((IAcciones)this).Color}";
        }
    }
}
