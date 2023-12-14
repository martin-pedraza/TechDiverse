using System;

namespace Entidades
{
    public class Conductor
    {
        private string nombre;
        private int[] dias;

        public Conductor(string nombre, int dia1, int dia2, int dia3, int dia4, int dia5, int dia6, int dia7)
        {
            this.nombre = nombre;
            this.dias = new int[7];
            this.dias[0] = dia1;
            this.dias[1] = dia2;
            this.dias[2] = dia3;
            this.dias[3] = dia4;
            this.dias[4] = dia5;
            this.dias[5] = dia6;
            this.dias[6] = dia7;
        }

        public Conductor(string nombre) : this(nombre, 0, 0, 0, 0, 0, 0, 0)
        {

        }

        public string Nombre { get { return this.nombre; } }
        public void AgregarHorasDia(int horas, int dia)
        {
            this.dias[dia - 1] = horas;
        }
        public int VerificarHorasDia(int dia)
        {
            return this.dias[dia - 1];
        }
        public int CantidadHorasSemana()
        {
            int sumadorHoras = 0;
            foreach (int horasDia in this.dias)
            {
                sumadorHoras += horasDia;
            }
            return sumadorHoras;
        }

        public static Conductor CompararHorasDia(Conductor[] conductores, int dia)
        {
            Conductor conductorMaximoKm = conductores[0];
            foreach (Conductor conductor in conductores)
            {
                if (dia == 7)
                {
                    if (conductor.CantidadHorasSemana() > conductorMaximoKm.CantidadHorasSemana())
                    {
                        conductorMaximoKm = conductor;
                    }
                }
                else
                {
                    if (conductor.VerificarHorasDia(dia) > conductorMaximoKm.VerificarHorasDia(dia))
                    {
                        conductorMaximoKm = conductor;
                    }
                }
            }
            return conductorMaximoKm;
        }
    }
}
