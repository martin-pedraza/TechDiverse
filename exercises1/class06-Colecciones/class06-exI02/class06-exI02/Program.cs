using System;
using System.Collections.Generic;

namespace class06_exI02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numerosLocosLista = new List<int>();
            Queue<int> numerosLocosFila = new Queue<int>();
            Stack<int> numerosLocosPila = new Stack<int>();

            for (int i = 0; i < 20; i++)
            {
                numerosLocosLista.Add(new Random().Next(-100, 100));
            }
            numerosLocosLista.Sort();
            foreach (int item in numerosLocosLista)
            {
                if (item != 0)
                {
                    numerosLocosFila.Enqueue(item);
                    numerosLocosPila.Push(item);
                }
            }

            Console.WriteLine("Lista creciente");
            foreach (int item in numerosLocosLista)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Fila creciente");
            foreach (int item in numerosLocosFila)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pila decreciente");
            foreach (int item in numerosLocosPila)
            {
                Console.WriteLine(item);
            }

            numerosLocosPila.Clear();
            numerosLocosFila.Clear();

            numerosLocosLista.Sort(OrdenarDecreciente);
            foreach (int item in numerosLocosLista)
            {
                if (item != 0)
                {
                    numerosLocosFila.Enqueue(item);
                    numerosLocosPila.Push(item);
                }
            }

            Console.WriteLine("Lista decreciente");
            foreach (int item in numerosLocosLista)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Fila decreciente");
            foreach (int item in numerosLocosFila)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pila creciente");
            foreach (int item in numerosLocosPila)
            {
                Console.WriteLine(item);
            }
        }

        public static int OrdenarDecreciente(int n1, int n2)
        {
            return n2 - n1;
        }
    }
}
