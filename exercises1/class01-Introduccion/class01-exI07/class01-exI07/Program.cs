using System;

namespace class01_exI07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreEmpleado;
            double valorHora;
            int aniosAntiguedad;
            int cantidadHorasTrabajadas;
            string palabraContinuar = "si";

            while (palabraContinuar == "si")
            {
                Console.WriteLine("Ingrese el nombre: ");
                nombreEmpleado = Console.ReadLine();

                do
                {
                    Console.WriteLine("Ingrese el valor de la hora: ");
                } while (!double.TryParse(Console.ReadLine(), out valorHora));

                do
                {
                    Console.WriteLine("Ingrese los años de antiguedad: ");
                } while (!int.TryParse(Console.ReadLine(), out aniosAntiguedad));

                do
                {
                    Console.WriteLine("Ingrese la cantidad de horas trabajadas: ");
                } while (!int.TryParse(Console.ReadLine(), out cantidadHorasTrabajadas));

                double sueldoBruto = valorHora * cantidadHorasTrabajadas + aniosAntiguedad * 150;

                Console.WriteLine($"Nombre: {nombreEmpleado}");
                Console.WriteLine($"Antiguedad: {aniosAntiguedad}   Valor de la hora: {valorHora}");
                Console.WriteLine($"Sueldo bruto: {sueldoBruto}     Sueldo neto: {sueldoBruto * 0.87}");

                Console.WriteLine("Desea continuar con otro empleado? si / no ");
                palabraContinuar = Console.ReadLine();
            }

        }
    }
}
