using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Competencia
    {
        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<AutoF1> competidores;

        private Competencia()
        {
            this.competidores = new List<AutoF1>();
        }
        public Competencia(short cantidadCompetidores, short cantidadVueltas) :this()
        {
            this.cantidadCompetidores = cantidadCompetidores;
            this.cantidadVueltas = cantidadVueltas;
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"N° competidores: {this.cantidadCompetidores}    Vueltas: {this.cantidadVueltas}");
            foreach (AutoF1 item in this.competidores)
            {
                sb.AppendLine(item.MostrarDatos());
            }
            return sb.ToString();
        }
        public static bool operator +(Competencia c, AutoF1 a)
        {
            if (c != a && c.competidores.Count < c.cantidadCompetidores)
            {
                a.EnCompetencia = true;
                a.VueltasRestantes = c.cantidadVueltas;
                a.CantidadCombustible = (short)new Random().Next(15, 100);
                c.competidores.Add(a);
                return true;
            }
            return false;
        }
        public static bool operator ==(Competencia c, AutoF1 a)
        {
            foreach (AutoF1 item in c.competidores)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Competencia c, AutoF1 a)
        {
            return !(c == a);
        }

    }
}
