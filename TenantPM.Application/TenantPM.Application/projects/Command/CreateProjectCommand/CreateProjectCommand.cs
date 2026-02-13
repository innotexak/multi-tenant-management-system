using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.CreateProjectCommand
{
    public class CreateProjectCommand : IRequest<CreateProjectCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
