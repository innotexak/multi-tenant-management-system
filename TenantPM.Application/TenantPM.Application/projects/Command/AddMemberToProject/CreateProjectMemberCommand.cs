using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Enums;

namespace TenantPM.Application.projects.Command.AddMemberToProject
{
    public class CreateProjectMemberCommand : IRequest<CreateProjectMemberCommandResponse>
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public RoleEnum ProjectRole { get; set; }
    }
}
