using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context) => _context = context;

        public async Task AddAsync(Company entity)
        {
            await _context.Set<Company>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company entity)
        {
            _context.Set<Company>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllAsync() => await _context.Set<Company>().ToListAsync();

        public async Task<Company?> GetByIdAsync(Guid id) => await _context.Set<Company>().FindAsync(id);

        public async Task UpdateAsync(Company entity)
        {
            _context.Set<Company>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }

