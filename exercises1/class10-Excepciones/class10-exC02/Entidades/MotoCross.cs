using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Motocross : VehiculoDeCarrera
    {
        private short cilindrada;

        public Motocross(short numero, string escuderia) : base(numero, escuderia)
        {
        }
        public Motocross(short numero, string escuderia, short cilindrada) : base(numero, escuderia)
        {
            Cilindrada = cilindrada;
        }

        public short Cilindrada { get => cilindrada; set => cilindrada = value; }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"\nCilidrada: {Cilindrada}";
        }

        public static bool operator ==(Motocross a1, Motocross a2)
        {
            return a1.Numero == a2.Numero && a1.Escuderia == a2.Escuderia && a1.Cilindrada == a2.Cilindrada;
        }
        public static bool operator !=(Motocross a1, Motocross a2)
        {
            return !(a1 == a2);
        }
    }
}
