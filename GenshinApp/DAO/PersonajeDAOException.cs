using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.DAO
{
    internal class PersonajeDAOException : Exception
    {
        public PersonajeDAOException()
        {
        }

        public PersonajeDAOException(string? message) : base(message)
        {
        }

        public PersonajeDAOException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PersonajeDAOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
