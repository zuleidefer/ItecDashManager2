using ItecDashManager.Domain.Entities.UserDashboard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.Service.Interfaces;

public interface IUserDashboardService
{
    Task<IEnumerable<UserDashboard>> GetAllAsync();
    Task<UserDashboard?> GetByIdAsync(Guid id);
    Task AddAsync(UserDashboard userDashboard);
    Task UpdateAsync(UserDashboard userDashboard);
    Task DeleteAsync(UserDashboard userDashboard);
}
