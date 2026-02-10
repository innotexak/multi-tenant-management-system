using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;
using TenantPM.Domain.Enums;


namespace TenantPM.Domain.Entities
{
    public class User: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public RoleEnum Role { get; set; }
   
    }
}
