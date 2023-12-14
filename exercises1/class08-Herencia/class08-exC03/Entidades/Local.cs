using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local : Llamada
    {
        protected float costo;

        public Local(float duracion, string nroDestino, string nroOrigen, float costo) : base(duracion, nroDestino, nroOrigen)
        {
            this.costo = costo;
        }

        public Local(Llamada llamada, float costo) : this(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen, costo)
        {

        }

        public override float CostoLlamada { get => CalcularCosto(); }

        private float CalcularCosto()
        {
            return Duracion * costo;
        }

        public override string Mostrar()
        {
            return base.Mostrar() + $"Costo: {CostoLlamada}";
        }
    }
}
