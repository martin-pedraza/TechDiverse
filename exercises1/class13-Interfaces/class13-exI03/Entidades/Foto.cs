using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Foto : IImprimible
    {
        public void Imprimir()
        {
            Console.WriteLine(DecirTexto());
        }
        public string DecirTexto()
        {
            return "Soy una selfie pal insta";
        }
    }
}
