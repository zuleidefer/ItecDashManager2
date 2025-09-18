using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.UserCompanyRole;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

    public class UserCompanyRoleRepository : IUserCompanyRoleRepository
    {
        private readonly DataContext _context;

        public UserCompanyRoleRepository(DataContext context) => _context = context;

        public async Task AddAsync(UserCompanyRole entity)
        {
            await _context.Set<UserCompanyRole>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserCompanyRole entity)
        {
            _context.Set<UserCompanyRole>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserCompanyRole>> GetAllAsync()
        {
            return await _context.Set<UserCompanyRole>()
                                 .Include(ucr => ucr.UserCompany)
                                    .ThenInclude(uc => uc.Company)
                                 .Include(ucr => ucr.UserCompany)
                                    .ThenInclude(uc => uc.User)
                                 .Include(ucr => ucr.Role)
                                 .ToListAsync();
        }

        public async Task<UserCompanyRole?> GetByIdAsync(Guid id) 
        {
            return await _context.Set<UserCompanyRole>()
                                 .Include(ucr => ucr.UserCompany)
                                    .ThenInclude(uc => uc.Company)
                                 .Include(ucr => ucr.UserCompany)
                                    .ThenInclude(uc => uc.User)
                                 .Include(ucr => ucr.Role)
                                 .FirstOrDefaultAsync(ucr => ucr.Id == id);
        }

        public async Task UpdateAsync(UserCompanyRole entity)
        {
            _context.Set<UserCompanyRole>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }

