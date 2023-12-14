using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTest
{
    [TestClass]
    public class GestionImpuestosTest
    {
        [TestMethod]
        public void CalcularTotalImpuestosAduana_DeberiaRetornarLaSumaDeLosImpuestosDeAduana()
        {
            GestionImpuestos gestion = new GestionImpuestos();
            PaqueteFragil fragil = new PaqueteFragil("111", 1000, "abc", "abc", 10);
            PaquetePesado pesado = new PaquetePesado("222", 1000, "abd", "abd", 12);
            gestion.RegistrarImpuestos(fragil);
            gestion.RegistrarImpuestos(pesado);
            decimal esperado = 700;

            decimal actual = gestion.CalcularTotalImpuestosAduana();

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularTotalImpuestosAfip_DeberiaRetornarLaSumaDeLosImpuestosDeAfip()
        {
            GestionImpuestos gestion = new GestionImpuestos();
            PaqueteFragil fragil = new PaqueteFragil("111", 1000, "abc", "abc", 10);
            PaquetePesado pesado = new PaquetePesado("222", 1000, "abd", "abd", 12);
            gestion.RegistrarImpuestos(fragil);
            gestion.RegistrarImpuestos(pesado);
            decimal esperado = 250;

            decimal actual = gestion.CalcularTotalImpuestosAfip();

            Assert.AreEqual(esperado, actual);
        }
    }
}
