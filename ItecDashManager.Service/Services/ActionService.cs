using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class ActionService : IActionService
    {
        private readonly IActionRepository _repository;

        public ActionService(IActionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Action action) => await _repository.AddAsync(action);

        public async Task DeleteAsync(Action action) => await _repository.DeleteAsync(action);

        public async Task<IEnumerable<Action>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Action?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task UpdateAsync(Action action) => await _repository.UpdateAsync(action);
    }

