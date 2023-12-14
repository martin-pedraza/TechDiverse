namespace Biblioteca
{
    public static class Int64Extension
    {
        public static int ContarCantidadDeDigitos(this Int64 value)
        {
            int sumador = 0;
            value = Math.Abs(value);
            for (int i = 0; i < value.ToString().Length; i++)
            {
                sumador++;
            }
            return sumador;
        }
    }
}