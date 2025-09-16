using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IActionService
    {
        public Task<IEnumerable<Action>> GetAllAsync();
        public Task<Action?> GetByIdAsync(Guid id);
        public Task AddAsync(Action action);
        public Task UpdateAsync(Action action);
        public Task DeleteAsync(Action action);
    }

