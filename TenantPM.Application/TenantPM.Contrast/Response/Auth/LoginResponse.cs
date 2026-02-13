using TenantPM.Application.Auth.Command.Login;
using TenantPM.Application.Auth.DTOs;
using TenantPM.Application.Users.DTOs;
using TenantPM.Domain.Common;

namespace TenantPM.Contrast.Response.Auth
{
    public class LoginResponse : ContrastBaseResponse<LoginResultDto>
    {
     
        public class LoginResultDto
        {
            public UserDto User { get; set; } = default!;
            public AuthTokenDto Tokens { get; set; } = default!;
        }
    }
}
