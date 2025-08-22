using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;

namespace ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

    public interface IUserRepository
    {
      Task<User> GetOneByEmailAsync(string email);
      Task AddAsync(User user);
    }

