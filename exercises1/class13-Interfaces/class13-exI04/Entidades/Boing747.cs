using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Boing747 : IVolador
    {
        private int horas;
        public Boing747(int horas = 0)
        {
            this.horas = horas;
        }
        public string DecirTexto()
        {
            return "Estoy volando como un avión";
        }

        public void Volador()
        {
            horas += 13;
            Console.WriteLine(DecirTexto());
        }
    }
}
