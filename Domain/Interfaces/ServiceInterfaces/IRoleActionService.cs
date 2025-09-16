using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.RoleAction;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IRoleActionService
    {
        public Task<IEnumerable<RoleAction>> GetAllAsync();
        public Task<RoleAction?> GetByIdAsync(Guid id);
        public Task AddAsync(RoleAction roleAction);
        public Task UpdateAsync(RoleAction roleAction);
        public Task DeleteAsync(RoleAction roleAction);
    }

