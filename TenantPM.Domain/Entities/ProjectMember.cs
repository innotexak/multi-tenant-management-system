using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;
using TenantPM.Domain.Enums;

namespace TenantPM.Domain.Entities
{
    public class ProjectMember: BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

        public RoleEnum ProjectRole { get; set; }
        public User User { get; set; } = null!;
    }
}
