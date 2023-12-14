using Biblioteca;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cuando el número es divisible por 3 y 5: " + 15.FizzBuzz());
            Console.WriteLine("Cuando el número es divisible sólo por 3: " + 6.FizzBuzz());
            Console.WriteLine("Cuando el número es divisible por sólo por 5: " + 10.FizzBuzz());
            Console.WriteLine("Cuando el número no es divisible por 5 o 3: " + 7.FizzBuzz());
        }
    }
}