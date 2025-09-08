using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.UserDashboard;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IUserDashboardService
    {
        Task<IEnumerable<UserDashboard>> GetAllAsync();
        Task<UserDashboard?> GetByIdAsync(Guid id);
        Task AddAsync(UserDashboard userDashboard);
        Task UpdateAsync(UserDashboard userDashboard);
        Task DeleteAsync(UserDashboard userDashboard);
    }

