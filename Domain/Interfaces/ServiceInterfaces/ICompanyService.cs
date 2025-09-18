using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.Company;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface ICompanyService
    {
        Task AddAsync(Company entity); 
        Task DeleteAsync(Company entity);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task UpdateAsync(Company entity);
    }

