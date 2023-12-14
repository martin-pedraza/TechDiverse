using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class UnaExcepcion : Exception
    {
        public UnaExcepcion()
        {
        }

        public UnaExcepcion(string? message) : base(message)
        {
        }

        public UnaExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnaExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
