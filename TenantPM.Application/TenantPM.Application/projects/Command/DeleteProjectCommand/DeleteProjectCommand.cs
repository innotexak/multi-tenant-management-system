using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;

namespace TenantPM.Application.projects.Command.DeleteProjectCommand
{
    public class DeleteProjectCommand : IRequest<BaseResponse<Guid>>
    {
        public Guid ProjectId { get; set; }
    }
}
