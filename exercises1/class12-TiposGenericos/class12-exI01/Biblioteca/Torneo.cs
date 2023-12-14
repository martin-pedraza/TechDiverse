using System.Text;

namespace Biblioteca
{
    public class Torneo<T>
        where T : Equipo
    {
        private List<T> equipos;
        private string nombre;

        public Torneo(string nombre)
        {
            this.nombre = nombre;
            equipos = new List<T>();
        }

        public static bool operator ==(Torneo<T> torneo, T equipo)
        {
            foreach (T item in torneo.equipos)
            {
                if (item == equipo)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Torneo<T> torneo, T equipo)
        {
            return !(torneo == equipo);
        }
        public static bool operator +(Torneo<T> torneo, T equipo)
        {
            if (torneo != equipo)
            {
                torneo.equipos.Add(equipo);
                return true;
            }
            return false;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre del torneo: {nombre}");
            foreach (T item in equipos)
            {
                sb.AppendLine(item.Ficha());
            }
            return sb.ToString();
        }
        private string CalcularPartido(T item1, T item2)
        {
            int marcador = 5;
            if (item1 is EquipoBasquet && item2 is EquipoBasquet)
            {
                marcador = 100;
            }
            int resultado1 = new Random().Next(marcador);
            int resultado2 = new Random().Next(marcador);
            return $"{item1.Nombre} {resultado1} - {resultado2} {item2.Nombre}";
        }
        public string JugarPartido
        {
            get
            {
                if (equipos.Count < 2)
                {
                    return "No hay suficientes equipos para jugar";
                }
                T item1 = equipos[new Random().Next(equipos.Count)];
                T item2;
                do
                {
                    item2 = equipos[new Random().Next(equipos.Count)];
                } while (item1 == item2);
                return CalcularPartido (item1, item2);
            }
        }
    }
}