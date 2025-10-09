using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;
public class UserDashboardRepository : IUserDashboardRepository
{

    private readonly DataContext _context;
    public UserDashboardRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDashboard>> GetAllAsync()
    {
       
        return await _context.UserDashboards
            .Include(ud => ud.User)
            .Include(ud => ud.Dashboard)
            .ToListAsync();
    }

    public async Task<UserDashboard?> GetByIdAsync(Guid id)
    {
        return await _context.UserDashboards
            .Include(ud => ud.User)
            .Include(ud => ud.Dashboard)
            .FirstOrDefaultAsync(ud => ud.Id == id);
    }

    public async Task AddAsync(UserDashboard userDashboard)
    {
        await _context.UserDashboards.AddAsync(userDashboard);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserDashboard userDashboard)
    {
        _context.UserDashboards.Update(userDashboard);
        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(UserDashboard userDashboard)
    {
        _context.UserDashboards.Remove(userDashboard);
        await _context.SaveChangesAsync();
    }
}        

        
    

