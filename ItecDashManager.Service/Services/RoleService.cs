using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Roles;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository) 
        {
            _repository = repository;
        }

        public async Task AddAsync(Role role) => await _repository.AddAsync(role);

        public async Task DeleteAsync(Role role) => await _repository.DeleteAsync(role);

        public async Task<IEnumerable<Role>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Role?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task UpdateAsync(Role role) => await _repository.UpdateAsync(role);

    }

