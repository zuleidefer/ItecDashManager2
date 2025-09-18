using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.UserCompany;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IUserCompanyService
    {
        Task AddAsync(UserCompany entity); 
        Task DeleteAsync(UserCompany entity);
        Task<IEnumerable<UserCompany>> GetAllAsync();
        Task<UserCompany?> GetByIdAsync(Guid id);
        Task UpdateAsync(UserCompany entity);
    }

