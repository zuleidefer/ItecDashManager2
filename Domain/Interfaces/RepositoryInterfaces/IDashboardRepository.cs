using ItecDashManager.Domain.Entities.Dashboard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

public interface IDashboardRepository
{
    Task<IEnumerable<Dashboard>> GetAllAsync();
    Task<Dashboard?> GetByIdAsync(Guid id);
    Task AddAsync(Dashboard dashboard);
    Task UpdateAsync(Dashboard dashboard);
    Task DeleteAsync(Dashboard dashboard);
}
