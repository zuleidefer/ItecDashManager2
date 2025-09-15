using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.Role;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

    public class RoleRepository : IRoleRepository
    {
    private readonly DataContext _context;
        public RoleRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Role role)
        {
            await _context.Set<Role>().AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            _context.Set<Role>().Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Set<Role>().ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Role>().FindAsync(id);
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Set<Role>().Update(role);
            await _context.SaveChangesAsync();
        }
    }

