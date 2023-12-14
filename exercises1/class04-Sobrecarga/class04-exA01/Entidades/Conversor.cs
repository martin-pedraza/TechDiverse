using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Conversor
    {
        public static float ConvertirKaF(float f)
        {
            return (f * (9 / 5)) - 459.67f;
        }
        public static float ConvertirCaF(float f)
        {
            return (f * (9 / 5)) + 32;
        }
        public static float ConvertirFaC(float f)
        {
            return (f - 32) * (5 / 9);
        }
        public static float ConvertirFaK(float f)
        {
            return (f + 459.67f) * (5 / 9);
        }
        public static float ConvertirKaC(float f)
        {
            float fahrenheit = ConvertirKaF(f);
            return ConvertirFaC(fahrenheit);
        }
        public static float ConvertirCaK(float f)
        {
            float fahrenheit = ConvertirCaF(f);
            return ConvertirFaK(fahrenheit);
        }

    }
}
