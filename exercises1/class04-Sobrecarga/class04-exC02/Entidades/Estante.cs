using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        private Producto[] productos;
        private int ubicacionEstante;

        private Estante(int capacidad)
        {
            this.productos = new Producto[capacidad];
        }
        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }
        public Producto[] GetProducto()
        {
            return this.productos;
        }
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Producto item in e.GetProducto())
            {
                sb.AppendLine(Producto.MostrarProducto(item));
            }
            return sb.ToString();
        }
        public static bool operator ==(Estante e, Producto p)
        {
            foreach (Producto item in e.GetProducto())
            {
                if (item is not null && item == p)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }
        public static bool operator +(Estante e, Producto p)
        {
            if (e != p)
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (e.productos[i] is null)
                    {
                        e.productos[i] = p;
                        return true;
                    }
                }
            }
            return false;
        }
        public static Estante operator -(Estante e, Producto p)
        {
            Estante nuevoEstante = new Estante(e.productos.Length, e.ubicacionEstante);
            for (int i = 0; i < e.productos.Length; i++)
            {
                if (e.productos[i] is not null && e.productos[i] != p)
                {
                    nuevoEstante.productos[i] = e.productos[i];
                }
            }
            return nuevoEstante;
        }

    }
}
