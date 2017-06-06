using System;
using System.Runtime.Serialization;

namespace EditoraCrescer.Dominio
{
    [Serializable]
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException()
        {
        }

        public RegraNegocioException(string message) : base(message)
        {
        }

        public RegraNegocioException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegraNegocioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}