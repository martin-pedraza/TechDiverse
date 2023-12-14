using System;
using System.Collections.Generic;

namespace class06_exI01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numerosLocos = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                numerosLocos.Add(new Random().Next(-100, 100));
            }

            foreach (int item in numerosLocos)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Ordenados decreciente");
            numerosLocos.Sort(OrdenarNumeros);
            foreach (int item in numerosLocos)
            {
                if (item > 0)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Ordenados creciente");
            numerosLocos.Sort();
            foreach (int item in numerosLocos)
            {
                if (item < 0)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static int OrdenarNumeros(int n1, int n2)
        {
            return n2 - n1;
        }
    }
}
