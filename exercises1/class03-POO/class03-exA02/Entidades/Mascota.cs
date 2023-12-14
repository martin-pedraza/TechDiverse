using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota
    {
        private string especie;
        private string nombre;
        private DateTime fechaNacimiento;
        private string[] vacunas;

        private Mascota()
        {
            this.vacunas = new string[0];
        }
        public Mascota(string especie, string nombre, DateTime fechaNacimiento, string vacuna) : this(especie, nombre, fechaNacimiento)
        {
            this.ExtenderArrayVacunas();
            this.vacunas[0] = vacuna;
        }

        public Mascota(string especie, string nombre, DateTime fechaNacimiento) : this()
        {
            this.especie = especie;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string Nombre { get { return this.nombre; } }
        public void AgregarVacuna(string vacuna)
        {
            this.ExtenderArrayVacunas();
            this.vacunas[vacunas.Length - 1] = vacuna;
        }
        private void ExtenderArrayVacunas()
        {
            int lenght = this.vacunas.Length;
            if (lenght != 0 && this.vacunas[lenght - 1] is not null)
            {
                String[] nuevasVacunas = new String[lenght + 1];

                for (int i = 0; i < lenght; i++)
                {
                    nuevasVacunas[i] = this.vacunas[i];
                }

                this.vacunas = nuevasVacunas;
            }
            else
            {
                this.vacunas = new string[1];
            }
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre}   Especie: {this.especie}     Nacimiento: {this.fechaNacimiento.ToString("MMMM dd, yyyy")}");
            for (int i = 0; i < this.vacunas.Length; i++)
            {
                sb.AppendLine($"Vacuna [{i + 1}]: {vacunas[i]}");
            }
            return sb.ToString();
        }
    }
}
