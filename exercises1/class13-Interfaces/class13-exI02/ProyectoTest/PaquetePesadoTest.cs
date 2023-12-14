using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTest
{
    [TestClass]
    public class PaquetePesadoTest
    {
        [TestMethod]
        public void TienePrioridad_DeberiaRetornarFalse()
        {
            PaquetePesado pesado = new PaquetePesado("111", 1000, "abc", "abc", 10);

            Assert.IsFalse(pesado.TienePrioridad);
        }

        [TestMethod]
        public void Impuestos_DeberiaRetornarValorImpuestoDel35PorcientoSobreCostoEnvio_CuandoEsImplementacionImplicita()
        {
            PaquetePesado pesado = new PaquetePesado("111", 1000, "abc", "abc", 10);
            decimal esperado = 350;

            decimal actual = pesado.Impuestos;

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Impuestos_DeberiaRetornarValorImpuestoDel25PorcientoSobreCostoEnvio_CuandoEsImplementacionExplicitaIAfip()
        {
            PaquetePesado pesado = new PaquetePesado("111", 1000, "abc", "abc", 10);
            decimal esperado = 250;

            decimal actual = ((IAfip)pesado).Impuestos;

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void AplicarImpuestos_DeberiaRetornarCostoDeEnvioMasImpuestosAfipYAduana()
        {
            PaquetePesado pesado = new PaquetePesado("111", 1000, "abc", "abc", 10);
            decimal esperado = 1600;

            decimal actual = pesado.AplicarImpuestos();

            Assert.AreEqual(esperado, actual);
        }
    }
}
