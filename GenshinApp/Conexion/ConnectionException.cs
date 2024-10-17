using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.Conexion
{
    internal class ConnectionException : Exception
    {
        public ConnectionException()
        {
        }

        public ConnectionException(string? message) : base(message)
        {
        }

    }
}
