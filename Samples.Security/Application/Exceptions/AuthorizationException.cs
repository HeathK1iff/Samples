
using System.Runtime.Serialization;
using System.Security;

namespace Samples.Security.Application.Exceptions;

internal class AuthorizationException : SecurityException
{
    public AuthorizationException() : this("User is not autorize")
    {
    }

    public AuthorizationException(string message) : base(message)
    {
    }

    public AuthorizationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
