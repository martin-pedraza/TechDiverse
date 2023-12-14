using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Dolar
    {
        private double cantidad;
        private static double cotzRespectoDolar;

        static Dolar()
        {
            Dolar.cotzRespectoDolar = 1;
        }

        public Dolar(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public double GetCantidad()
        {
            return this.cantidad;
        }

        public static double GetCotizacion()
        {
            return Dolar.cotzRespectoDolar;
        }

        public static explicit operator Euro(Dolar d)
        {
            return new Euro(d.GetCantidad() / Euro.GetCotizacion());
        }
        
        public static explicit operator Peso(Dolar d)
        {
            return new Peso(d.GetCantidad() * Peso.GetCotizacion());
        }

        public static implicit operator Dolar(double d)
        {
            return new Dolar(d);
        }

        public static bool operator !=(Dolar d, Euro e)
        {
            return d.GetCantidad() != (e.GetCantidad() * Euro.GetCotizacion());
        }
        
        public static bool operator !=(Dolar d, Peso p)
        {
            return d.GetCantidad() != (p.GetCantidad() / Peso.GetCotizacion());
        }

        public static bool operator !=(Dolar d1, Dolar d2)
        {
            return d1.GetCantidad() != d2.GetCantidad();
        }

        public static bool operator ==(Dolar d, Euro e)
        {
            return !(d != e);
        }

        public static bool operator ==(Dolar d, Peso p)
        {
            return !(d != p);
        }

        public static bool operator ==(Dolar d1, Dolar d2)
        {
            return !(d1 != d2);
        }

        public static Dolar operator -(Dolar d, Euro e)
        {
            return d.GetCantidad() - (e.GetCantidad() * Euro.GetCotizacion());
        }
        public static Dolar operator -(Dolar d, Peso p)
        {
            return d.GetCantidad() - (p.GetCantidad() / Peso.GetCotizacion());
        }
        public static Dolar operator +(Dolar d, Euro e)
        {
            return d.GetCantidad() + (e.GetCantidad() * Euro.GetCotizacion());
        }
        public static Dolar operator +(Dolar d, Peso p)
        {
            return d.GetCantidad() + (p.GetCantidad() / Peso.GetCotizacion());
        }
    }
}
