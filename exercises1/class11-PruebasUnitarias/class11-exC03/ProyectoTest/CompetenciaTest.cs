using Entidades;
namespace ProyectoTest
{
    [TestClass]
    public class CompetenciaTest
    {
        [TestMethod]
        public void CompetenciaConstructor_CuandoSeInstancia_DeberiaInstanciarseLaLista()
        {
            Competencia competencia = new Competencia(3, 5, Competencia.TipoCompetencia.F1);

            Assert.IsNotNull(competencia.Competidores);
        }

        [TestMethod]
        [ExpectedException(typeof(CompetenciaNoDisponibleException))]
        public void OperadorSuma_CuandoSeAgregaUnVehiculoDeOtroTipo_DeberiaLanzarCompetenciaNoDisponibleException()
        {
            Competencia competencia = new Competencia(3, 5, Competencia.TipoCompetencia.F1);
            Motocross moto = new Motocross(10, "Ford");

            if (competencia + moto)
            { }
        }

        [TestMethod]
        public void OperadorSuma_CuandoSeAgregaUnVehiculoDelTipo_DeberiaRetornarTrue()
        {
            Competencia competencia = new Competencia(3, 5, Competencia.TipoCompetencia.MotoCross);
            Motocross moto = new Motocross(10, "Ford");

            Assert.IsTrue(competencia + moto);
        }

        [TestMethod]
        public void OperadorIgual_CuandoSeAgregaUnVehiculo_DeberiaRetornarTrue()
        {
            Competencia competencia = new Competencia(3, 5, Competencia.TipoCompetencia.MotoCross);
            Motocross moto = new Motocross(10, "Ford");

            Assert.IsTrue(competencia + moto);
            Assert.IsTrue(competencia == moto);
        }

        [TestMethod]
        public void OperadorDistinto_CuandoSeQuitaUnVehiculo_DeberiaRetornarTrue()
        {
            Competencia competencia = new Competencia(3, 5, Competencia.TipoCompetencia.MotoCross);
            Motocross moto = new Motocross(10, "Ford");

            Assert.IsTrue(competencia + moto);
            Assert.IsTrue(competencia == moto);
            Assert.IsTrue(competencia - moto);
            Assert.IsTrue(competencia != moto);
        }
    }
}