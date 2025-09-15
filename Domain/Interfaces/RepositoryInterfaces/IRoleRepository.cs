using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Role;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(Guid id);
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);

    }

