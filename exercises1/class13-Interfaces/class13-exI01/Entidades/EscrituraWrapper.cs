using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EscrituraWrapper
    {
        public string texto;
        public ConsoleColor color;

        public EscrituraWrapper(string texto, ConsoleColor color)
        {
            this.texto = texto;
            this.color = color;
        }
    }
}
