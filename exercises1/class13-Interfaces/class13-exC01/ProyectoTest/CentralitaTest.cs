using Entidades;

namespace ProyectoTest
{
    [TestClass]
    public class CentralitaTest
    {
        [TestMethod]
        public void Centralita_CuandoSeInstancia_DeberiaInstanciarseLaLista()
        {
            Centralita centralita = new Centralita();

            Assert.IsNotNull(centralita.Llamadas);
        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void OperadorSuma_CuandoSeCargueUnaLlamadaLocalExistente_DeberiaLanzarCentralitaException()
        {
            Centralita centralita = new Centralita();
            Local l1 = new Local(100, "12341234", "12341234", 100);
            Local l2 = l1;

            centralita += l1;
            centralita += l2;
        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void OperadorSuma_CuandoSeCargueUnaLlamadaProvincialExistente_DeberiaLanzarCentralitaException()
        {
            Centralita centralita = new Centralita();
            Provincial l1 = new Provincial(100, Provincial.Franja.Franja_1, "12341234", "12341234");
            Provincial l2 = l1;

            centralita += l1;
            centralita += l2;
        }
    }
}