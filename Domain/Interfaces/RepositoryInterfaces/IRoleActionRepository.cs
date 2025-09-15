using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.RoleAction;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

    public interface IRoleActionRepository
    {
        Task<IEnumerable<RoleAction>> GetAllAsync();
        Task<RoleAction?> GetByIdAsync(Guid id);
        Task AddAsync(RoleAction roleAction);
        Task UpdateAsync(RoleAction roleAction);
        Task DeleteAsync(RoleAction roleAction);
    }

