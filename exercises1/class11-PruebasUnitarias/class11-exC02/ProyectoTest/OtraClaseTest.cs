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
    public class OtraClaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(MiExcepcion))]
        public void OtraClaseConstructor_CuandoSeInstancia_DeberiaLanzarMiExcepcion()
        {
            OtraClase otraClase = new OtraClase();
        }
    }
}
