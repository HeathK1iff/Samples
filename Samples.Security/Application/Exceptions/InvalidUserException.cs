using Samples.Security.Application.Abstractions;
using System.Runtime.Serialization;

namespace Samples.Security.Application.Exceptions;

internal class InvalidUserException : ExceptionBase
{
    public InvalidUserException() : this("Invalid user\n")
    {
    }

    public InvalidUserException(string message) : base(message)
    {
    }

    public InvalidUserException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InvalidUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
