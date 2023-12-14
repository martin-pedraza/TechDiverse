using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTest
{
    [TestClass]
    public class LlamadaTest
    {
        [TestMethod]
        public void OperadorIgual_CuandoComparaCuatroLlamadasConMismosAtributos_DeberiaRetornarTrueSiLosTiposDeLlamadaSonIguales()
        {
            Centralita centralita = new Centralita();
            Local l1 = new Local(100, "12341234", "12341234", 100);
            Local l2 = new Local(120, "12341234", "12341234", 120);
            Provincial l3 = new Provincial(140, Provincial.Franja.Franja_1, "12341234", "12341234");
            Provincial l4 = new Provincial(160, Provincial.Franja.Franja_2, "12341234", "12341234");

            Assert.IsTrue(l1 == l2);
            Assert.IsFalse(l1 == l3);
            Assert.IsFalse(l1 == l4);
            Assert.IsFalse(l2 == l3);
            Assert.IsFalse(l2 == l4);
            Assert.IsTrue(l3 == l4);
        }
    }
}
