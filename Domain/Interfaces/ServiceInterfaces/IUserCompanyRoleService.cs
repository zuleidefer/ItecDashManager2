using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.UserCompanyRole;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IUserCompanyRoleService
    {
        Task AddAsync(UserCompanyRole entity); 
        Task DeleteAsync(UserCompanyRole entity);
        Task<IEnumerable<UserCompanyRole>> GetAllAsync();
        Task<UserCompanyRole?> GetByIdAsync(Guid id);
        Task UpdateAsync(UserCompanyRole entity);
    }

