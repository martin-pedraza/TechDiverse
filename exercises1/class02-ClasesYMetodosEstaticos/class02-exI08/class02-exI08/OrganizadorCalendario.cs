using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exI08
{
    public static class OrganizadorCalendario
    {
        private static bool VerificarAnioBisiesto(int anio)
        {
            return anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0);
        }

        public static int VerificarDiasMes(int mes, int anio)
        {
            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    if (VerificarAnioBisiesto(anio))
                    {
                        return 29;
                    }
                    return 28;
            }
        }

        private static int CalcularDias(int dia, int mes, int anio)
        {
            int sumadorDiasHoy = 0;
            for (int i = 1; i < anio - 1; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    sumadorDiasHoy += VerificarDiasMes(j, i);
                }
            }
            for (int i = 1; i < mes - 1; i++)
            {
                sumadorDiasHoy += VerificarDiasMes(i, anio);
            }
            sumadorDiasHoy += dia;
            return sumadorDiasHoy;
        }

        public static int CalcularDiferencia(int dia, int mes, int anio)
        {
            return CalcularDias(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year) - CalcularDias(dia, mes, anio);
        }
    }
}
