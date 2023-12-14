using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VehiculoDeCarrera
    {
        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        public VehiculoDeCarrera(short numero, string escuderia)
        {
            Escuderia = escuderia;
            Numero = numero;
            EnCompetencia = false;
            CantidadCombustible = 0;
            VueltasRestantes = 0;
        }

        public short CantidadCombustible { get { return this.cantidadCombustible; } set { this.cantidadCombustible = value; } }
        public bool EnCompetencia { get { return this.enCompetencia; } set { this.enCompetencia = value; } }
        public string Escuderia { get => escuderia; set => escuderia = value; }
        public short Numero { get => numero; set => numero = value; }
        public short VueltasRestantes { get { return this.vueltasRestantes; } set { this.vueltasRestantes = value; } }

        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Escuderia: {Escuderia} - #{Numero}");
            sb.AppendLine($"Combustible: {CantidadCombustible} Vueltas: {VueltasRestantes} En conmpetencia: {EnCompetencia}");
            return sb.ToString();
        }
        public static bool operator ==(VehiculoDeCarrera a, VehiculoDeCarrera b)
        {
            return a.Numero == b.Numero && a.Escuderia == b.Escuderia;
        }
        public static bool operator !=(VehiculoDeCarrera a, VehiculoDeCarrera b)
        {
            return !(a == b);
        }
    }
}
