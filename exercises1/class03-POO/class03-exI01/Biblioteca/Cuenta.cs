using System;

namespace Biblioteca
{
    public class Cuenta
    {
        private string titular;
        private decimal cantidad;


        public string Titular { get { return this.titular; } set {this.titular = value;} }
        public decimal Cantidad { get { return this.cantidad; } set {this.cantidad = value;} }

        public Cuenta(string titular, decimal cantidad)
        {
            this.Titular = titular;
            this.Cantidad = cantidad;
        }

        public string Mostrar()
        {
            return $"Titular: {this.Titular}     Cantidad: {this.Cantidad}";
        }

        public void Ingresar(decimal montoIngresado)
        {
            if (montoIngresado > 0)
            {
                this.Cantidad += montoIngresado;
            }
        }

        public void Retirar(decimal montoRetirado)
        {
            this.Cantidad -= montoRetirado;
        }
    }
}
