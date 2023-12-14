using System;

namespace class02_exI08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int diaNacimiento;
            int mesNacimiento;
            int anioNacimiento;
            int cantDiasMes;
            do
            {
                Console.WriteLine("Ingrese el año de su fecha de nacimiento: ");
            } while (!int.TryParse(Console.ReadLine(), out anioNacimiento)
                        || anioNacimiento <= 0
                        || anioNacimiento > DateTime.Now.Year);

            do
            {
                Console.WriteLine("Ingrese el mes (numero) de su fecha de nacimiento: ");
            } while (!int.TryParse(Console.ReadLine(), out mesNacimiento)
                        || mesNacimiento <= 0
                        || mesNacimiento > 12
                        || mesNacimiento > DateTime.Now.Month);

            cantDiasMes = OrganizadorCalendario.VerificarDiasMes(mesNacimiento, anioNacimiento);

            do
            {
                Console.WriteLine("Ingrese el dia (numero) de su fecha de nacimiento: ");
            } while (!int.TryParse(Console.ReadLine(), out diaNacimiento)
                        || diaNacimiento <= 0
                        || diaNacimiento > cantDiasMes
                        || diaNacimiento > DateTime.Now.Day);

            Console.WriteLine($"Ha nacido {OrganizadorCalendario.CalcularDiferencia(diaNacimiento, mesNacimiento, anioNacimiento)} dias atras");
        }
    }
}
