using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private long dni;
        private string nombre;

        public Persona(string nombre)
        {
            Nombre = nombre;
        }

        public Persona(long dni, string nombre) : this(nombre)
        {
            Dni = dni;
        }

        public long Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public virtual string MostrarDatos()
        {
            string mensaje = Dni != 0 ? $"DNI: {Dni}" : "";
            return $"Nombre: {Nombre} {mensaje} ";
        }
    }
}
