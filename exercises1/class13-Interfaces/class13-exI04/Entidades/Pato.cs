using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pato : IVolador
    {
        private int energia;
        public Pato(int energia = 10)
        {
            this.energia = energia;
        }
        public string DecirTexto()
        {
            return "Estoy volando como un pato ¡ Cuak !";
        }

        public void Volador()
        {
            energia -= 5;   
            Console.WriteLine(DecirTexto());
        }

    }
}
