using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.Domain.Entities.UserCompanyRole;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class UserCompanyRoleService : IUserCompanyRoleService
    {
        private readonly IUserCompanyRoleRepository _repository;

        public UserCompanyRoleService(IUserCompanyRoleRepository repository) => _repository = repository;

        public async Task AddAsync(UserCompanyRole entity) => await _repository.AddAsync(entity);
        public async Task DeleteAsync(UserCompanyRole entity) => await _repository.DeleteAsync(entity);
        public async Task<IEnumerable<UserCompanyRole>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<UserCompanyRole?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(UserCompanyRole entity) => await _repository.UpdateAsync(entity);
    }
   


