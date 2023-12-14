using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Impresora
    {
        private List<IImprimible> colaDeImpresion;

        public Impresora()
        {
            colaDeImpresion = new List<IImprimible>();
        }

        public List<IImprimible> ColaDeImpresion { get => colaDeImpresion; }

        public static void ImprimirTodo(Impresora impresora)
        {
            foreach (IImprimible item in impresora.ColaDeImpresion)
            {
                item.Imprimir();
            }
        }

        public static void AgregarImprimible(Impresora impresora, IImprimible imprimible)
        {
            impresora.ColaDeImpresion.Add(imprimible);
        }
        public static string DecirTextos(Impresora impresora)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IImprimible item in impresora.ColaDeImpresion)
            {
                sb.AppendLine(item.DecirTexto());
            }
            return sb.ToString();
        }
    }
}
