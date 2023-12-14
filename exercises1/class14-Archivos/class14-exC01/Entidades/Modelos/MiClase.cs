using Entidades.Excepciones;

namespace Entidades.Modelos
{
    public class MiClase
    {
        public static void MetodoEstatico()
        {
            throw new DivideByZeroException();
        }

        public MiClase()
        {
            try
            {
                MetodoEstatico();
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
        }

        public MiClase(int n)
        {
            try
            {
                MiClase miClase = new MiClase();
            }
            catch (DivideByZeroException e)
            {
                throw new UnaExcepcion("Excepcion en mi clase", e);
            }
        }
    }
}