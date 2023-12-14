using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class OtraClase
    {
        public OtraClase()
        {
            try
            {
                MiClase miClase = new MiClase(0);
            }
            catch (UnaExcepcion e)
            {
                throw new MiExcepcion("Excepcion en otra clase", e);
            }
        }
    }
}
