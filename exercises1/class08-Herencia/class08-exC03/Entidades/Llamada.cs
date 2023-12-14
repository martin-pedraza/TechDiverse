using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum TipoLlamada { Local, Provincial, Todas };
    public class Llamada
    {

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        public float Duracion { get => duracion; }
        public string NroDestino { get => nroDestino; }
        public string NroOrigen { get => nroOrigen; }
        public virtual float CostoLlamada { get; }

        public virtual string Mostrar()
        {
            return $"Duracion: {Duracion} Origen: {NroOrigen} Destino: {NroDestino} ";
        }
        public static int OrdenarPorDuracion(Llamada a, Llamada b)
        {
            return (int)a.Duracion - (int)b.Duracion;
        }
    }
}
