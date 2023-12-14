using System;
using System.Text;

namespace Entidades
{
    public class AutoF1
    {
        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        public AutoF1(short numero, string escuderia)
        {
            this.escuderia = escuderia;
            this.numero = numero;
            this.enCompetencia = false;
            this.cantidadCombustible = 0;
            this.vueltasRestantes = 0;
        }

        public short CantidadCombustible { get { return this.cantidadCombustible; } set { this.cantidadCombustible = value; } }
        public bool EnCompetencia { get { return this.enCompetencia; } set { this.enCompetencia = value; } }
        public short VueltasRestantes { get { return this.vueltasRestantes; } set { this.vueltasRestantes = value; } }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Escuderia: {this.escuderia} - #{this.numero}");
            sb.AppendLine($"Combustible: {this.CantidadCombustible} Vueltas: {this.VueltasRestantes} En conmpetencia: {this.EnCompetencia}");
            return sb.ToString();
        }
        public static bool operator ==(AutoF1 a1, AutoF1 a2)
        {
            return a1.numero == a2.numero && a1.escuderia == a2.escuderia;
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2)
        {
            return !(a1 == a2);
        }

    }
}
