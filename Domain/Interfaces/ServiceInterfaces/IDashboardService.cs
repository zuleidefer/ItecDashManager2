using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Dashboard;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IDashboardService
    {
        Task<IEnumerable<Dashboard>> GetAllAsync();
        Task<Dashboard?> GetByIdAsync(Guid id);
        Task AddAsync(Dashboard dashboard);
        Task UpdateAsync(Dashboard dashboard);
        Task DeleteAsync(Dashboard dashboard);
    }

