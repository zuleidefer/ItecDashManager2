using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Roles;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IRoleService
    {
        public Task<IEnumerable<Role>> GetAllAsync();
        public Task<Role?> GetByIdAsync(Guid id);
        public Task AddAsync(Role role);
        public Task UpdateAsync(Role role);
        public Task DeleteAsync(Role role);
    }

