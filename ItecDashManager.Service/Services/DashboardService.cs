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
        public DashboardService (IDashboardRepository repository)
         {

         }

        public Task AddAsync(Dashboard dashboard)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Dashboard dashboard)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dashboard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dashboard?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Dashboard dashboard)
        {
            throw new NotImplementedException();
        }
}

