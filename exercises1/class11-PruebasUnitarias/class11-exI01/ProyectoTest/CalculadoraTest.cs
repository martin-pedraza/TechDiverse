using Biblioteca;

namespace ProyectoTest
{
    [TestClass]
    public class CalculadoraTest
    {
        [TestMethod]
        public void Add_CuandoRecibeStringVacio_DeberiaRetornarCero()
        {
            string numeros = "";
            int esperado = 0;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Add_CuandoRecibeStringConUnNumero_DeberiaRetornarElMismoNumero()
        {
            string numeros = "1";
            int esperado = 1;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Add_CuandoRecibeStringConDosNumerosSeparadosPorComa_DeberiaRetornarLaSuma()
        {
            string numeros = "1,2";
            int esperado = 3;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Add_CuandoRecibeStringConVariosNumerosSeparadosPorComa_DeberiaRetornarLaSuma()
        {
            string numeros = "1,2,3,4,5";
            int esperado = 15;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Add_CuandoRecibeStringConVariosNumerosSeparadosPorComaOSaltoDeLinea_DeberiaRetornarLaSuma()
        {
            string numeros = "1,2,3\n4,5";
            int esperado = 15;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Add_CuandoRecibeStringConDosNumerosSeparadosPorComaOSaltoDeLineaODelimitadorPersonalizado_DeberiaRetornarLaSuma()
        {
            string numeros = "//;\n1;2";
            int esperado = 3;
            Calculadora calculadora = new Calculadora();

            int actual = calculadora.Add(numeros);

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativoNoPermitidoException))]
        public void Add_CuandoRecibeStringConNumeroNegativoSeparadosPorlimitadorPersonalizado_DeberiaLanzarNegativoNoPermitidoException()
        {
            string numeros = "//;\n1;-2";
            Calculadora calculadora = new Calculadora();

            calculadora.Add(numeros);
        }
    }
}