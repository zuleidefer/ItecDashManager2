using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.Service.Services;

public class UserDashboardService : IUserDashboardService
{
    private readonly IUserDashboardRepository _userDashboardRepository;
    
    public UserDashboardService(IUserDashboardRepository userDashboardRepository)
    {
        _userDashboardRepository = userDashboardRepository;
    }

    public Task<IEnumerable<UserDashboard>> GetAllAsync()
    {
        return _userDashboardRepository.GetAllAsync();
    }

    public Task<UserDashboard?> GetByIdAsync(Guid id)
    {
        return _userDashboardRepository.GetByIdAsync(id);
    }

    public Task AddAsync(UserDashboard userDashboard)
    {
        return _userDashboardRepository.AddAsync(userDashboard);
    }

    public Task UpdateAsync(UserDashboard userDashboard)
    {
        return _userDashboardRepository.UpdateAsync(userDashboard);
    }

    public Task DeleteAsync(UserDashboard userDashboard)
    {
        return _userDashboardRepository.DeleteAsync(userDashboard);
    }
}
