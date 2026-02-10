using TenantPM.Application.Auth.DTOs;
using TenantPM.Application.Users.DTOs;
using TenantPM.Domain.Common;

namespace TenantPM.Application.Auth.Command.Login
{
    public class LoginCommandResponse : BaseResponse<LoginResultDto>
    {
    }

    public class LoginResultDto
    {
        public UserDto User { get; set; } = default!;
        public AuthTokenDto Tokens { get; set; } = default!;
    }
}
