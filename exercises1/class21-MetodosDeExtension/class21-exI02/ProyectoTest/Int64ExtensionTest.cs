using Biblioteca;
namespace ProyectoTest
{
    [TestClass]
    public class Int64ExtensionTest
    {
        [TestMethod]
        public void ContarCantidadDeDigitos_CuandoRecibeUnDigito_RetornaUno()
        {
            long numero = 2;
            int esperado = 1;

            int actual = numero.ContarCantidadDeDigitos();

            Assert.AreEqual(esperado, actual);
        }
        [TestMethod]
        public void ContarCantidadDeDigitos_CuandoRecibeDosDigitosNegativos_RetornaDos()
        {
            long numero = -42;
            int esperado = 2;

            int actual = numero.ContarCantidadDeDigitos();

            Assert.AreEqual(esperado, actual);
        }
    }
}