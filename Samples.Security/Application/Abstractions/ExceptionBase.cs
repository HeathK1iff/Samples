using System.Runtime.Serialization;

namespace Samples.Security.Application.Abstractions;

[Serializable]
internal abstract class ExceptionBase : Exception
{
    protected ExceptionBase()
    {
    }

    protected ExceptionBase(string message) : base(message)
    {
    }

    protected ExceptionBase(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
