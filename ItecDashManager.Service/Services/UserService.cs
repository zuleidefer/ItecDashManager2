using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;

namespace ItecDashManager.Service.Services;

    public class UserService : IUserService
{
    public Task<User> AuthenticateAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public object GetTokenData(User user)
    {
        throw new NotImplementedException();
    }
}

