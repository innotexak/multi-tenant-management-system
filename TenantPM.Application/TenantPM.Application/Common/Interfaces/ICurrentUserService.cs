using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
        Guid? UserId { get; }
        string? Email { get; }
        string? Role { get; }
    }
}
