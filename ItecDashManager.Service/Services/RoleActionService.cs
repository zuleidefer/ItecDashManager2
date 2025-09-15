using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.RoleAction;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class RoleActionService : IRoleActionService
    {
        private readonly IRoleActionRepository _repository;

        public RoleActionService(IRoleActionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(RoleAction roleAction) => await _repository.AddAsync(roleAction);

        public async Task DeleteAsync(RoleAction roleAction) => await _repository.DeleteAsync(roleAction);

        public async Task<IEnumerable<RoleAction>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<RoleAction?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task UpdateAsync(RoleAction roleAction) => await _repository.UpdateAsync(roleAction);
    }
    

