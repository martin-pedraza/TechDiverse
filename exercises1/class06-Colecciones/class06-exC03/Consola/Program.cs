using Entidades;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string datoIngresado = string.Empty;
            Dictionary<int, Stack<Producto>> maquinaExpendedora = new Dictionary<int, Stack<Producto>>();

            //maquinaExpendedora.Add(1, new Producto("Seven up", "700", "1000"));
            //maquinaExpendedora.Add(2, new Producto("Agua Villavicencio", "250", "1000"));
            //maquinaExpendedora.Add(3, new Producto("Bonobom", "150", "1000"));
            //maquinaExpendedora.Add(4, new Producto("Baggio de manzana", "350", "1000"));
            //maquinaExpendedora.Add(5, new Producto("Huevo Kinder", "450", "1000"));
            //maquinaExpendedora.Add(6, new Producto("Rocklet", "150", "1000"));
            //maquinaExpendedora.Add(7, new Producto("Mini oreo", "600", "1000"));
            //maquinaExpendedora.Add(8, new Producto("Gomitas Mogul", "500", "1000"));
            //maquinaExpendedora.Add(9, new Producto("Agua saborizada Levite de naranja", "400", "1000"));
            //maquinaExpendedora.Add(10, new Producto("Papas fritas Lays", "400", "1000"));

            Stack<Producto> posicionUno = new Stack<Producto>();
            Stack<Producto> posicionDos = new Stack<Producto>();
            Stack<Producto> posicionTres = new Stack<Producto>();

            maquinaExpendedora.Add(1, posicionUno);
            maquinaExpendedora.Add(2, posicionDos);
            maquinaExpendedora.Add(3, posicionTres);

            posicionUno.Push(new Producto("Seven up", "700", "1000"));
            posicionDos.Push(new Producto("Agua Villavicencio", "250", "1000"));
            posicionTres.Push(new Producto("Bonobom", "150", "1000"));

            do
            {
                Console.Clear();

                Console.WriteLine("--------------------");
                Console.WriteLine("--------------------");
                foreach (KeyValuePair<int, Stack<Producto>> entry in maquinaExpendedora)
                {
                    Console.WriteLine($"{entry.Key} - {entry.Value.Peek().Mostrar()}");
                }
                Console.WriteLine("--------------------");
                Console.WriteLine("--------------------");

                Console.WriteLine("Escribe el codigo del producto o 's': ");
                datoIngresado = Console.ReadLine().ToLower();

                if (datoIngresado != "s" && int.TryParse(datoIngresado, out int codigo))
                {
                    if (maquinaExpendedora.ContainsKey(codigo))
                    {
                        Console.WriteLine($"Se eligio el producto: {maquinaExpendedora[codigo].Peek().Mostrar()} - {codigo}");
                        maquinaExpendedora[codigo].Pop();
                        if (maquinaExpendedora[codigo].Count == 0)
                        {
                            maquinaExpendedora.Remove(codigo);
                        }
                        Console.ReadKey();
                    }
                }

            } while (datoIngresado != "s");
        }


    }
}