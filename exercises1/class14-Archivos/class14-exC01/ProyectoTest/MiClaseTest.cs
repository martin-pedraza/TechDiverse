using Entidades.Excepciones;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTest
{
    [TestClass]
    public class MiClaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void MiClaseConstructor_CuandoSeInstancia_DeberiaLanzarDivideByZeroException()
        {
            MiClase miClase = new MiClase();
        }

        [TestMethod]
        [ExpectedException(typeof(UnaExcepcion))]
        public void MiClaseConstructor_CuandoSeInstancia_DeberiaLanzarUnaExcepcion()
        {
            MiClase miClase = new MiClase(0);
        }
    }
}
