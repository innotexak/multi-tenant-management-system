using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }
    }
}
