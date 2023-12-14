using System;
using System.Text;

namespace Entidades
{
    public class AutoF1 : VehiculoDeCarrera
    {
        private short caballosDeFuerza;

        public AutoF1(short numero, string escuderia) : base(numero, escuderia)
        {
        }
        public AutoF1(short numero, string escuderia, short caballosDeFuerza) : base(numero, escuderia)
        {
            CaballosDeFuerza = caballosDeFuerza;
        }

        public short CaballosDeFuerza { get => caballosDeFuerza; set => caballosDeFuerza = value; }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"Caballos de fuerza: {CaballosDeFuerza}\n";
        }
        public static bool operator ==(AutoF1 a1, AutoF1 a2)
        {
            return a1.Numero == a2.Numero && a1.Escuderia == a2.Escuderia && a1.CaballosDeFuerza == a2.CaballosDeFuerza;
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2)
        {
            return !(a1 == a2);
        }

    }
}
