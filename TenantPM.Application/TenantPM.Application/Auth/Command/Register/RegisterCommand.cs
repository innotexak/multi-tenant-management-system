using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Application.Auth.Command.Register
{
    public class RegisterCommand : IRequest<RegisterCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
