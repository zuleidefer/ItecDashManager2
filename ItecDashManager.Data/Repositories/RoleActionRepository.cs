using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.RoleAction;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

    public class RoleActionRepository : IRoleActionRepository
    {
        private readonly DataContext _context;

        public RoleActionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RoleAction roleAction)
        {
            await _context.Set<RoleAction>().AddAsync(roleAction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoleAction roleAction)
        {
            _context.Set<RoleAction>().Remove(roleAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleAction>> GetAllAsync()
        {
            return await _context.Set<RoleAction>().ToListAsync();
        }

        public async Task<RoleAction?> GetByIdAsync(Guid id)
        {
            return await _context.Set<RoleAction>().FindAsync(id);
        }

        public async Task UpdateAsync(RoleAction roleAction)
        {
            _context.Set<RoleAction>().Update(roleAction);
            await _context.SaveChangesAsync();
        }

    }

