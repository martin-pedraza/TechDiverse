using System.Text;
using static Entidades.Llamada;

namespace Entidades
{
    public class Centralita : IGuardar<string>
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

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razon social: {razonSocial}");
            sb.AppendLine($"Ganancia total: {GananciaPorTotal} Provincial: {GananciaPorProvincial} Local: {GananciaPorLocal}");
            foreach (Llamada item in Llamadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public override string ToString()
        {
            return Mostrar();
        }

        private void AgregarLlamada(Llamada l1)
        {
            Llamadas.Add(l1);
        }

        public bool Guardar()
        {
            return true;
        }

        public string Leer()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Centralita c, Llamada l)
        {
            foreach (Llamada item in c.Llamadas)
            {
                if (item == l)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Centralita c, Llamada l)
        {
            return !(c == l);
        }

        public static Centralita operator +(Centralita c, Llamada l)
        {
            if (c != l)
            {
                c.AgregarLlamada(l);
            }
            else
            {
                throw new CentralitaException("Ya se encuentra la llamada", "Centralita", "Operador de suma");
            }
            return c;
        }
    }
}