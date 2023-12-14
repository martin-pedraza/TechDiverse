using Entidades;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AutoF1 a1 = new AutoF1(1, "escu1", 100);
            AutoF1 a2 = new AutoF1(4, "escu2", 150);
            AutoF1 a3 = new AutoF1(5, "escu3", 99);
            AutoF1 a4 = new AutoF1(1, "escu1", 100);
            AutoF1 a5 = new AutoF1(2, "escu4", 101);
            Motocross m1 = new Motocross(6, "escu5", 50);
            Competencia competencia = new Competencia(7, 10, Competencia.TipoCompetencia.F1);

            if (competencia + a1)
            {
                Console.WriteLine(competencia.MostrarDatos());
            }
            else
            {
                Console.WriteLine("NO SE AGREGO");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            if (competencia + a2)
            {
                Console.WriteLine(competencia.MostrarDatos());
            }
            else
            {
                Console.WriteLine("NO SE AGREGO");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            if (competencia + a3)
            {
                Console.WriteLine(competencia.MostrarDatos());
            }
            else
            {
                Console.WriteLine("NO SE AGREGO");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            if (competencia + a4)
            {
                Console.WriteLine(competencia.MostrarDatos());
            }
            else
            {
                Console.WriteLine("NO SE AGREGO");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            if (competencia + a5)
            {
                Console.WriteLine(competencia.MostrarDatos());
            }
            else
            {
                Console.WriteLine("NO SE AGREGO");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            try
            {
                if (competencia + m1)
                {
                    Console.WriteLine(competencia.MostrarDatos());
                }
            }
            catch (CompetenciaNoDisponibleException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}