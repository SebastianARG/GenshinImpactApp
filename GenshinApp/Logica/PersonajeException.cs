using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.Logica
{
    internal class PersonajeException : Exception
    {
        public PersonajeException()
        {
        }

        public PersonajeException(string? message) : base(message)
        {
        }

        public PersonajeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PersonajeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
