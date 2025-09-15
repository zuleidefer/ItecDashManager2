using ItecDashManager.Domain.Entities.Action;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces
{
    public interface IActionRepository
    {
        Task<IEnumerable<Action>> GetAllAsync();
        Task<Action?> GetByIdAsync(Guid id);
        Task AddAsync(Action action);
        Task UpdateAsync(Action action);
        Task DeleteAsync(Action action);
    }
}