using System;
using Entidades;

namespace class03_exA01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conductor conductorResultado;

            Conductor[] conductores = new Conductor[3];
            conductores[0] = new Conductor("Mario", 15, 15, 15, 15, 150, 0, 0);
            conductores[1] = new Conductor("Henrique", 20, 100, 0, 40, 50, 300, 0);
            conductores[2] = new Conductor("Cesar");

            for (int i = 1; i <= 7; i++)
            {
                conductores[2].AgregarHorasDia(30, i);
            }

            conductorResultado = Conductor.CompararHorasDia(conductores, 7);
            Console.WriteLine($"Conductor MAX horas en semana: {conductorResultado.Nombre}");

            conductorResultado = Conductor.CompararHorasDia(conductores, 3);
            Console.WriteLine($"Conductor MAX horas del dia 3: {conductorResultado.Nombre}");

            conductorResultado = Conductor.CompararHorasDia(conductores, 5);
            Console.WriteLine($"Conductor MAX horas del dia 5: {conductorResultado.Nombre}");
        }
    }
}
