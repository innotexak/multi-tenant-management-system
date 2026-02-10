using MediatR;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;

namespace TenantPM.Application.projects.Queries.GetProject
{
    public class ProjectDetailQuery : IRequest<ProjectDetailVn>
    {
        public Guid ProjectId { get; set; }
    }
}
