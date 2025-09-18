using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class UserCompanyService : IUserCompanyService
    {
        private readonly IUserCompanyRepository _repository;

        public UserCompanyService(IUserCompanyRepository repository) => _repository = repository;

        public async Task AddAsync(UserCompany entity) => await _repository.AddAsync(entity);
        public async Task DeleteAsync(UserCompany entity) => await _repository.DeleteAsync(entity);
        public async Task<IEnumerable<UserCompany>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<UserCompany?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(UserCompany entity) => await _repository.UpdateAsync(entity);
    }

