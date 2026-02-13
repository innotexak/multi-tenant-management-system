using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Contrast.Common;

namespace TenantPM.Contrast.Response.Project
{
    public class ProjectDetailsResponse: ContrastBaseResponse<ProjectInfo>
    {
    }

    public class ProjectInfo: ContrastDateItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
