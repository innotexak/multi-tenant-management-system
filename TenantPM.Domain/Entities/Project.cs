using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;

namespace TenantPM.Domain.Entities
{
    public class Project: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
