using Samples.Bridge.Abstractions;

namespace Samples.Bridge.Dto;

public sealed class CheckCredentialRequest : ServiceRequestBase
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}