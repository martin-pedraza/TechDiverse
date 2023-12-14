using System;
using System.Text;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private string domicilio;
        private string telefono;
        private Mascota[] mascotas;

        public Cliente(string nombre, string apellido, string domicilio, string telefono, Mascota mascota)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.mascotas = new Mascota[1];
            this.mascotas[0] = mascota;
        }
        public void AgregarMascota(Mascota mascota)
        {
            this.ExtenderArrayMascotas();
            this.mascotas[mascotas.Length - 1] = mascota;
        }
        private void ExtenderArrayMascotas()
        {
            int lenght = this.mascotas.Length;
            if (this.mascotas[lenght - 1] is not null)
            {
                Mascota[] nuevaMascotas = new Mascota[lenght + 1];

                for (int i = 0; i < lenght; i++)
                {
                    nuevaMascotas[i] = this.mascotas[i];
                }

                this.mascotas = nuevaMascotas;
            }
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre}   Apellido: {this.apellido}");
            sb.AppendLine($"Domicilio: {this.domicilio}     Telefono: {this.telefono}");
            for (int i = 0; i < mascotas.Length; i++)
            {
                sb.AppendLine($"Mascota [{i + 1}]: {this.mascotas[i].Mostrar()}");
            }
            return sb.ToString();
        }
    }
}
