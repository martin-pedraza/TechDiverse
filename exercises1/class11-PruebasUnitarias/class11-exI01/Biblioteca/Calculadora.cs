namespace Biblioteca
{
    public class Calculadora
    {
        public int Add(string numeros)
        {
            if (String.IsNullOrEmpty(numeros))
            {
                return 0;
            }

            char[] caracteresEspeciales = new char[3];
            caracteresEspeciales[0] = ',';
            caracteresEspeciales[1] = '\n';

            if (numeros.Length > 3 && numeros[0] == '/' && numeros[1] == '/')
            {
                caracteresEspeciales[2] = numeros[2];
            }

            string[] arrayNumeros = numeros.Split(caracteresEspeciales);

            int sumador = 0;
            foreach (string item in arrayNumeros)
            {
                if (int.TryParse(item, out int numero))
                {
                    if (numero < 0)
                    {
                        throw new NegativoNoPermitidoException(numero.ToString());
                    }
                    sumador += numero;
                }
            }

            return sumador;
        }
    }
}