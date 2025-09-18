using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.Domain.Entities.Actions;

namespace ItecDashManager.Service.Services;

    public class ActionService : IActionService
    {
        private readonly IActionRepository _repository;

        public ActionService(IActionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ApplicationAction action) => await _repository.AddAsync(action);

        public async Task DeleteAsync(ApplicationAction action) => await _repository.DeleteAsync(action);

        public async Task<IEnumerable<ApplicationAction>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<ApplicationAction?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task UpdateAsync(ApplicationAction action) => await _repository.UpdateAsync(action);
    }

