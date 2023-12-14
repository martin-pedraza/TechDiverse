using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NumeroBinario
    {
        public string numero;
        private NumeroBinario(string numero)
        {
            this.numero = numero;
        }
        public int ConvertirADecimal()
        {
            return Conversor.ConvertirBinarioADecimal(int.Parse(this.numero));
        }
        public static implicit operator NumeroBinario(string s)
        {
            return new NumeroBinario(s);
        }
        public static explicit operator string(NumeroBinario b)
        {
            return b.numero;
        }
        public static string operator +(NumeroBinario b, NumeroDecimal d)
        {
            double resultado = b.ConvertirADecimal() + d.numero;
            return Conversor.ConvertirDecimalABinario((int)resultado);
        }
        public static string operator -(NumeroBinario b, NumeroDecimal d)
        {
            double resultado = b.ConvertirADecimal() - d.numero;
            return Conversor.ConvertirDecimalABinario((int)resultado);
        }
        public static bool operator ==(NumeroBinario b, NumeroDecimal d)
        {
            return b.ConvertirADecimal() == d.numero;
        }
        public static bool operator !=(NumeroBinario b, NumeroDecimal d)
        {
            return !(b == d);
        }

    }
}
