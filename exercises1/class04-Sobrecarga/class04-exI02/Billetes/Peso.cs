using System;

namespace Billetes
{
    public class Peso
    {
        private double cantidad;
        private static double cotzRespectoDolar;

        static Peso()
        {
            Peso.cotzRespectoDolar = 102.65;
        }

        public Peso(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Peso(double cantidad, double cotzRespectoDolar) : this(cantidad)
        {
            Peso.cotzRespectoDolar = cotzRespectoDolar;
        }

        public double GetCantidad()
        {
            return this.cantidad;
        }

        public static double GetCotizacion()
        {
            return Peso.cotzRespectoDolar;
        }

        public static explicit operator Euro(Peso p)
        {
            return new Euro((p.GetCantidad() / Peso.GetCotizacion()) / Euro.GetCotizacion());
        }

        public static explicit operator Dolar(Peso p)
        {
            return new Dolar(p.GetCantidad() / Peso.GetCotizacion());
        }

        public static implicit operator Peso(double d)
        {
            return new Peso(d);
        }
        public static bool operator ==(Peso p, Euro e)
        {
            return ((Euro)p).GetCantidad() == e.GetCantidad();
        }
        public static bool operator !=(Peso p, Euro e)
        {
            return !(p == e);
        }
        public static bool operator ==(Peso p, Dolar d)
        {
            return ((Dolar)p).GetCantidad() == d.GetCantidad();
        }
        public static bool operator !=(Peso p, Dolar d)
        {
            return !(p == d);
        }
        public static bool operator ==(Peso p1, Peso p2)
        {
            return p1.GetCantidad() == p2.GetCantidad();
        }
        public static bool operator !=(Peso p1, Peso p2)
        {
            return !(p1 == p2);
        }
        public static Peso operator +(Peso p, Euro e)
        {
            return p.GetCantidad() + ((Peso)e).GetCantidad();
        }
        public static Peso operator +(Peso p, Dolar d)
        {
            return p.GetCantidad() + ((Peso)d).GetCantidad();
        }
        public static Peso operator -(Peso p, Euro e)
        {
            return p.GetCantidad() - ((Peso)e).GetCantidad();
        }
        public static Peso operator -(Peso p, Dolar d)
        {
            return p.GetCantidad() - ((Peso)d).GetCantidad();
        }
    }
}
