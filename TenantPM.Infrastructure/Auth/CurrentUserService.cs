using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TenantPM.Application.Common.Interfaces;

namespace TenantPM.Infrastructure.Auth
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext?.User
            ?? new ClaimsPrincipal(new ClaimsIdentity());

        public Guid? UserId
        {
            get
            {
                var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(value, out var id) ? id : null;
            }
        }

        public string? Email =>
            User.FindFirst(ClaimTypes.Email)?.Value;

        public string? Role =>
            User.FindFirst(ClaimTypes.Role)?.Value;
    }
}
