namespace Biblioteca
{
    public static class Int32Extension
    {
        public static string FizzBuzz(this Int32 numero)
        {
            if (numero % 3 == 0 & numero % 5 == 0)
            {
                return "Fizz Buzz";
            }
            if (numero % 3 == 0)
            {
                return "Fizz";
            }
            if(numero % 5 == 0)
            {
                return "Buzz";
            }
            return numero.ToString();
        }
    }
}