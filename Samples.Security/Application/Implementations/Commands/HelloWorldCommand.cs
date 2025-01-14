using Samples.Security.Application.Abstractions;
using Samples.Security.BussinesLayer.Interfaces;

namespace Samples.Security.Application.Implementations.Commands;

[Command("hello-world")]
internal class HelloWorldCommand : CommandBase
{
    public HelloWorldCommand(IAccountService accountService, IConsole console) : base(accountService, console)
    {
    }

    protected override void DoExecute(IConsole console)
    {
        console.Say("Hello world!!!\n");
    }
}
