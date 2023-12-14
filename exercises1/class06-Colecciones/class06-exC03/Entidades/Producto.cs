using System.Text;

namespace Entidades
{
    public class Producto
    {
        private string nombre;
        private double precio;
        private int codigo;

        public Producto(string nombre, string precio, string codigo)
        {
            Nombre = nombre;
            Precio = precio;
            Codigo = codigo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { set => precio = double.Parse(value); }
        public string Codigo { get => codigo.ToString(); init => codigo = int.Parse(value); }

        public string Mostrar()
        {
            return $"{nombre} - ${precio}";
        }
    }
}