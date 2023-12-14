using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        private DateTime fechaNacimiento;

        public DirectorTecnico(string nombre) : base(nombre)
        {
        }

        public DirectorTecnico(string nombre, DateTime fechaNacimiento) : base(nombre)
        {
            this.fechaNacimiento = fechaNacimiento;
        }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + fechaNacimiento.ToString();
        }
        public static bool operator ==(DirectorTecnico a, DirectorTecnico b)
        {
            return a.fechaNacimiento == b.fechaNacimiento && a.Dni == b.Dni;
        }
        public static bool operator !=(DirectorTecnico a , DirectorTecnico b)
        {
            return !(a == b);
        }
    }
}
