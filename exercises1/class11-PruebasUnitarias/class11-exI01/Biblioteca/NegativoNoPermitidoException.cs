using System.Runtime.Serialization;

namespace Biblioteca
{
    public class NegativoNoPermitidoException : Exception
    {
        public NegativoNoPermitidoException()
        {
        }

        public NegativoNoPermitidoException(string? message) : base(message)
        {
        }

        public NegativoNoPermitidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NegativoNoPermitidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}