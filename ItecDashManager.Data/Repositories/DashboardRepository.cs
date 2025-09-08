using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly DataContext _context;

    public DashboardRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Dashboard dashboard)
    {
        await _context.Dashboards.AddAsync(dashboard);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Dashboard dashboard)
    {
        _context.Dashboards.Remove(dashboard);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Dashboard>> GetAllAsync()
    {
        return await _context.Dashboards.ToListAsync();
    }

    public async Task<Dashboard?> GetByIdAsync(Guid id)
    {
        return await _context.Dashboards.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task UpdateAsync(Dashboard dashboard)
    {
        _context.Dashboards.Update(dashboard);
        await _context.SaveChangesAsync();
    }
}
