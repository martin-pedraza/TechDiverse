using System.Text;
using static Entidades.Llamada;

namespace Entidades
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        private string razonSocial;

        public Centralita()
        {
            listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa) : this()
        {
            razonSocial = nombreEmpresa;
        }

        public List<Llamada> Llamadas { get => listaDeLlamadas; }
        public float GananciaPorLocal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            }
        }
        public float GananciaPorProvincial
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GananciaPorTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float sumador = 0;
            foreach (Llamada item in Llamadas)
            {
                if ((typeof(Local) == item.GetType() && tipo == TipoLlamada.Local) 
                    || (typeof(Provincial) == item.GetType() && tipo == TipoLlamada.Provincial) 
                    || tipo == TipoLlamada.Todas)
                {
                    sumador += item.CostoLlamada;
                }
            }
            return sumador;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razon social: {razonSocial}");
            sb.AppendLine($"Ganancia total: {GananciaPorTotal} Provincial: {GananciaPorProvincial} Local: {GananciaPorLocal}");
            foreach (Llamada item in Llamadas)
            {
                sb.AppendLine(item.Mostrar());
            }
            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }
    }
}