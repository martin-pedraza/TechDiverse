using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class02_exI05
{
    public class TablaMultiplicacion
    {
        public static string ElaborarTabla(int numero)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tabla de multiplicar del número {numero}");
            for (int i = 0; i < 10; i++)
            {
                sb.AppendLine($"{numero} x {i + 1} = {numero * (i + 1)}");
            }
            return sb.ToString();
        }

    }
}
