using System;

namespace Biblioteca
{
    public class Persona
    {
        private string nombre;
        private DateTime fechaDeNacimiento;
        private int dni;

        public Persona(string nombre, DateTime fechaDeNacimiento, int dni)
        {
            this.Nombre = nombre;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Dni = dni;
        }

        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public DateTime FechaDeNacimiento { get { return this.fechaDeNacimiento; } set { this.fechaDeNacimiento = value; } }
        public int Dni { get { return this.dni; } set { this.dni = value; } }

        private int CalcularEdad()
        {
            return DateTime.Now.Year - this.FechaDeNacimiento.Year;
        }

        public string Mostrar()
        {
            return $"Nombre: {this.Nombre}  " +
                $"Nacimiento: {this.FechaDeNacimiento}  " +
                $"DNI: {this.Dni}   " +
                $"Edad: {this.CalcularEdad()}";
        }

        public string EsMayorDeEdad()
        {
            return this.CalcularEdad() >= 18 ? "Es mayor de edad" : "es menor";
        }
    }
}
