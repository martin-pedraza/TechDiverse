using Biblioteca;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un numero:\t");
            long numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Numero de \t\t" + numero.ContarCantidadDeDigitos().ToString() + " digitos");
        }
    }
}