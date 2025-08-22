using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

namespace ItecDashManager.Data.Repositories;

public class UserRepository : IUserRepository

{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetOneByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}

