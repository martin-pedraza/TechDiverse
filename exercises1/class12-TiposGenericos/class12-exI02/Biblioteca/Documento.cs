namespace Biblioteca
{
    public class Documento
    {
        private int numero;
        public Documento(int numero)
        {
            this.Numero = numero;
        }

        public int Numero { get => numero; set => numero = value; }
    }
}