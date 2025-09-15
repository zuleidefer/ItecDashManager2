using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IActionService
    {
        Task<IEnumerable<Action>> GetAllAsync();
        Task<Action?> GetByIdAsync(Guid id);
        Task AddAsync(Action action);
        Task UpdateAsync(Action action);
        Task DeleteAsync(Action action);
    }

