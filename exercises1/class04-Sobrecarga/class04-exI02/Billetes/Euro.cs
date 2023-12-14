using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Euro
    {
        private double cantidad;
        private static double cotzRespectoDolar;

        static Euro()
        {
            Euro.cotzRespectoDolar = 1.17;
        }

        public Euro(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Euro(double cantidad, double cotzRespectoDolar) :this(cantidad)
        {
            Euro.cotzRespectoDolar = cotzRespectoDolar;
        }

        public double GetCantidad()
        {
            return this.cantidad;
        }

        public static double GetCotizacion()
        {
            return Euro.cotzRespectoDolar;
        }


        public static explicit operator Dolar(Euro e)
        {
            return new Dolar(e.GetCantidad() * Euro.GetCotizacion());
        }

        public static explicit operator Peso(Euro e)
        {
            return new Peso(e.GetCantidad() * Euro.GetCotizacion() * Peso.GetCotizacion());
        }

        public static implicit operator Euro(double d)
        {
            return new Euro(d);
        }

        public static bool operator !=(Euro e, Dolar d)
        {
            return e.GetCantidad() != (d.GetCantidad() / Euro.GetCotizacion());
        }

        public static bool operator !=(Euro e, Peso p)
        {
            return e.GetCantidad() != ((p.GetCantidad() / Peso.GetCotizacion()) / Euro.GetCotizacion());
        }

        public static bool operator !=(Euro e1, Euro e2)
        {
            return e1.GetCantidad() != e2.GetCantidad();
        }

        public static bool operator ==(Euro e, Dolar d)
        {
            return !(e != d);
        }

        public static bool operator ==(Euro e, Peso p)
        {
            return !(e != p);
        }

        public static bool operator ==(Euro e1, Euro e2)
        {
            return !(e1 != e2);
        }

        public static Euro operator -(Euro e, Dolar d)
        {
            return e.GetCantidad() - (d.GetCantidad() / Euro.GetCotizacion());
        }
        public static Euro operator -(Euro e, Peso p)
        {
            return e.GetCantidad() - ((p.GetCantidad() / Peso.GetCotizacion()) / Euro.GetCotizacion());
        }
        public static Euro operator +(Euro e, Dolar d)
        {
            return e.GetCantidad() + (d.GetCantidad() / Euro.GetCotizacion());
        }
        public static Euro operator +(Euro e, Peso p)
        {
            return e.GetCantidad() + ((p.GetCantidad() / Peso.GetCotizacion()) / Euro.GetCotizacion());
        }
    }
}
