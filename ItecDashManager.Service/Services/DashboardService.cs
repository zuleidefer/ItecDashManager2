using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

public class DashboardService : IDashboardService
{
   
    private readonly IDashboardRepository _repository;

    public DashboardService(IDashboardRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Dashboard dashboard)
        => await _repository.AddAsync(dashboard);

    public async Task DeleteAsync(Dashboard dashboard)
        => await _repository.DeleteAsync(dashboard);

    public async Task<IEnumerable<Dashboard>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Dashboard?> GetByIdAsync(Guid id)
        => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Dashboard dashboard)
        => await _repository.UpdateAsync(dashboard);
}