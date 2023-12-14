﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local : Llamada, IGuardar<Local>
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
        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private float CalcularCosto()
        {
            return Duracion * costo;
        }

        protected override string Mostrar()
        {
            return base.Mostrar() + $"Costo: {CostoLlamada}";
        }

        public override bool Equals(object? obj)
        {
            return obj.GetType() == typeof(Local);
        }

        public override string ToString()
        {
            return Mostrar();
        }

        public bool Guardar()
        {
            throw new NotImplementedException();
        }

        public Local Leer()
        {
            throw new NotImplementedException();
        }
    }
}
