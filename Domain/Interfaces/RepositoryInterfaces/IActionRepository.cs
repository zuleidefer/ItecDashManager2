using ItecDashManager.Domain.Entities.Action;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Actions;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces
{
    public interface IActionRepository
    {
        Task<IEnumerable<ApplicationAction>> GetAllAsync();
        Task<ApplicationAction?> GetByIdAsync(Guid id);
        Task AddAsync(ApplicationAction action);
        Task UpdateAsync(ApplicationAction action);
        Task DeleteAsync(ApplicationAction action);
    }
}