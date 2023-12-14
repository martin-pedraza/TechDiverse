using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ArchivoIncorrectoException : Exception
    {
        public ArchivoIncorrectoException(string? message) : base(message)
        {
        }

        public ArchivoIncorrectoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
