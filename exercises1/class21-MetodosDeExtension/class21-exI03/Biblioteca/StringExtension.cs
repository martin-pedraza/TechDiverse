namespace Biblioteca
{
    public static class StringExtension
    {
        public static int ContarSignosPuntuacion(this string value)
        {
            int sumador = 0;
            foreach (char c in value)
            {
                if (c == '.' || c == ',' || c == ';')
                {
                    sumador++;
                }
            }
            return sumador;
        }
    }
}