using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincial : Llamada
    {
        public enum Franja { Franja_1, Franja_2, Franja_3 };

        protected Franja franjaHoraria;

        public Provincial(float duracion, Franja franjaHoraria, string nroDestino, string nroOrigen) : base(duracion, nroDestino, nroOrigen)
        {
            this.franjaHoraria = franjaHoraria;
        }

        public Provincial(Franja franjaHoraria, Llamada llamada) : this(llamada.Duracion, franjaHoraria, llamada.NroDestino, llamada.NroOrigen)
        {

        }

        public override float CostoLlamada
        {
            get { return CalcularCosto(); }
        }
        private float CalcularCosto()
        {
            switch (franjaHoraria)
            {
                case Franja.Franja_1:
                    return 0.99f * Duracion;
                case Franja.Franja_2:
                    return 1.25f * Duracion;
                default:
                    return 0.66f * Duracion;
            }
        }

        public override string Mostrar()
        {
            return base.Mostrar() + $"Franja: {franjaHoraria.ToString()} Costo: {CostoLlamada}";
        }
    }
}
