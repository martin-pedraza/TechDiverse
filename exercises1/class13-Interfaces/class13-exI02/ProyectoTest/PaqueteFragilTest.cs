using Biblioteca;
namespace ProyectoTest
{
    [TestClass]
    public class PaqueteFragilTest
    {
        [TestMethod]
        public void TienePrioridad_DeberiaRetornarTrue()
        {
            PaqueteFragil fragil = new PaqueteFragil("111", 1000, "abc", "abc", 10);

            Assert.IsTrue(fragil.TienePrioridad);
        }

        [TestMethod]
        public void Impuestos_DeberiaRetornarValorImpuestoDel35PorcientoSobreCostoEnvio()
        {
            PaqueteFragil fragil = new PaqueteFragil("111", 1000, "abc", "abc", 10);
            decimal esperado = 350;

            decimal actual = fragil.Impuestos;

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void AplicarImpuestos_DeberiaRetornarCostoDeEnvioMasImpuestoAduana()
        {
            PaqueteFragil fragil = new PaqueteFragil("111", 1000, "abc", "abc", 10);
            decimal esperado = 1350;

            decimal actual = fragil.AplicarImpuestos();

            Assert.AreEqual(esperado, actual);
        }
    }
}