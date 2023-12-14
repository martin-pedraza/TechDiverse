using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BuzzLightyear : IVolador
    {
        private int experiencia;
        public BuzzLightyear(int experiencia = 0)
        {
            this.experiencia = experiencia;
        }

        public string DecirTexto()
        {
            return "Al infinito y mas alla";
        }

        public void Volador()
        {
            experiencia += 3;
            Console.WriteLine(DecirTexto());
        }
    }
}
