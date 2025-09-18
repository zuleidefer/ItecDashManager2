using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository) => _repository = repository;

        public async Task AddAsync(Company entity) => await _repository.AddAsync(entity);
        public async Task DeleteAsync(Company entity) => await _repository.DeleteAsync(entity);
        public async Task<IEnumerable<Company>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Company?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task UpdateAsync(Company entity) => await _repository.UpdateAsync(entity);
    }

