using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

    public class ActionRepository : IActionRepository
    {
        private readonly DataContext _context;

        public ActionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Action action)
        {
            await _context.Set<Action>().AddAsync(action);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Action action)
        {
            _context.Set<Action>().Remove(action);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Action>> GetAllAsync()
        {
            return await _context.Set<Action>().ToListAsync();
        }

        public async Task<Action?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Action>().FindAsync(id);
        }

        public async Task UpdateAsync(Action action)
        {
            _context.Set<Action>().Update(action);
            await _context.SaveChangesAsync();
        }
    }

