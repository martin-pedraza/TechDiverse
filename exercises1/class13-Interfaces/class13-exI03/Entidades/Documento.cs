using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Documento : IImprimible
    {
        public void Imprimir()
        {
            Console.WriteLine(DecirTexto());
        }
        public string DecirTexto()
        {
            return "Soy un documento de word";
        }
    }
}
