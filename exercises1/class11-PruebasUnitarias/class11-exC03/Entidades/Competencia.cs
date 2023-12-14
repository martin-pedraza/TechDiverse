using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Competencia
    {
        public enum TipoCompetencia { F1, MotoCross };

        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<VehiculoDeCarrera> competidores;
        private TipoCompetencia tipo;

        public TipoCompetencia Tipo { get => tipo; set => tipo = value; }
        public short CantidadVueltas { get => cantidadVueltas; set => cantidadVueltas = value; }
        public short CantidadCompetidores { get => cantidadCompetidores; set => cantidadCompetidores = value; }
        public List<VehiculoDeCarrera> Competidores { get => competidores; set => competidores = value; }

        public VehiculoDeCarrera this[int i]
        {
            get
            {
                return competidores[i];
            }
        }

        private Competencia()
        {
            this.competidores = new List<VehiculoDeCarrera>();
        }
        public Competencia(short cantidadCompetidores, short cantidadVueltas, TipoCompetencia tipo) : this()
        {
            CantidadCompetidores = cantidadCompetidores;
            CantidadVueltas = cantidadVueltas;
            Tipo = tipo;
        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"N° competidores: {CantidadCompetidores}    Vueltas: {CantidadVueltas}");
            foreach (VehiculoDeCarrera item in competidores)
            {
                sb.AppendLine(item.MostrarDatos());
            }
            return sb.ToString();
        }
        public static bool operator +(Competencia c, VehiculoDeCarrera v)
        {
            try
            {
                if (c != v && c.competidores.Count < c.CantidadCompetidores)
                {
                    v.EnCompetencia = true;
                    v.VueltasRestantes = c.CantidadVueltas;
                    v.CantidadCombustible = (short)new Random().Next(15, 100);
                    c.competidores.Add(v);
                    return true;
                }
            }
            catch (CompetenciaNoDisponibleException ex)
            {
                throw new CompetenciaNoDisponibleException("Competencia incorrecta", "Competencia", "Operador suma", ex);
            }
            return false;
        }
        public static bool operator ==(Competencia c, VehiculoDeCarrera v)
        {
            if ((c.Tipo == TipoCompetencia.F1 && v.GetType() == typeof(AutoF1)) || (c.Tipo == TipoCompetencia.MotoCross && v.GetType() == typeof(Motocross)))
            {
                foreach (VehiculoDeCarrera item in c.competidores)
                {
                    if (item == v)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new CompetenciaNoDisponibleException("El vehículo no corresponde a la competencia", "Competencia", "Operador igual");
        }
        public static bool operator !=(Competencia c, VehiculoDeCarrera v)
        {
            return !(c == v);
        }

        public static bool operator -(Competencia c, VehiculoDeCarrera v)
        {
            if (c == v)
            {
                List<VehiculoDeCarrera> nuevo = new List<VehiculoDeCarrera> ();
                foreach (VehiculoDeCarrera item in c.Competidores)
                {
                    if (item == v)
                    {
                        continue;
                    }
                    nuevo.Add (item);
                }
                c.Competidores = nuevo;
                return true;
            }
            return false;
        }
    }
}
