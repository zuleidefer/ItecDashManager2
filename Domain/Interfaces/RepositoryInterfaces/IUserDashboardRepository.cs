using ItecDashManager.Domain.Entities.UserDashboard;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

public interface IUserDashboardRepository
{
    Task<IEnumerable<UserDashboard>> GetAllAsync();
    Task<UserDashboard?> GetByIdAsync(Guid id);
    Task AddAsync(UserDashboard userDashboard);
    Task UpdateAsync(UserDashboard userDashboard);
    Task DeleteAsync(UserDashboard userDashboard);

}
