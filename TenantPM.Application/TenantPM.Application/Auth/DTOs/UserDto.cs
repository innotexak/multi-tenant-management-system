using TenantPM.Domain.Enums;

namespace TenantPM.Application.Users.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
