using System.Text;

namespace Entidades
{
    public class TorreDeControl
    {
        private List<IVolador> voladores;

        public TorreDeControl()
        {
            voladores = new List<IVolador>();
        }

        public List<IVolador> Voladores { get => voladores; }

        public void VuelenTodos()
        {
            foreach (IVolador item in Voladores)
            {
                item.Volador();
            }
        }
        public void AgregarVolador(IVolador volador)
        {
            Voladores.Add(volador);
        }
        public string DecirTextos()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IVolador item in Voladores)
            {
                sb.AppendLine(item.DecirTexto());
            }
            return sb.ToString();
        }
    }
}