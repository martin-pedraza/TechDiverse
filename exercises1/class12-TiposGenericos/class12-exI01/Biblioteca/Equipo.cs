using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public abstract class Equipo
    {
        private string nombre;
        private DateTime fechaCreacion;

        public string Nombre { get => nombre; set => nombre = value; }

        public Equipo(string nombre, DateTime fechaCreacion)
        {
            this.Nombre = nombre;
            this.fechaCreacion = fechaCreacion;
        }

        public static bool operator ==(Equipo e1, Equipo e2)
        {
            return e1.Nombre == e2.Nombre && e1.fechaCreacion == e2.fechaCreacion;
        }
        public static bool operator !=(Equipo e1, Equipo e2)
        {
            return !(e1 == e2);
        }
        public string Ficha()
        {
            return $"{Nombre} fundado el {fechaCreacion.ToString()}";
        }
    }
}
