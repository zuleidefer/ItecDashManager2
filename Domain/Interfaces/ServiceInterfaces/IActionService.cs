using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Actions;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IActionService
    {
        public Task<IEnumerable<ApplicationAction>> GetAllAsync();
        public Task<ApplicationAction?> GetByIdAsync(Guid id);
        public Task AddAsync(ApplicationAction action);
        public Task UpdateAsync(ApplicationAction action);
        public Task DeleteAsync(ApplicationAction action);
    }

