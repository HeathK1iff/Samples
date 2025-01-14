using Samples.Security.DataAccess.Entity;

namespace Samples.Security.BussinesLayer.Entities;

internal class UserDto
{
    public Guid Id { get; set; }
    public string LoginName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
