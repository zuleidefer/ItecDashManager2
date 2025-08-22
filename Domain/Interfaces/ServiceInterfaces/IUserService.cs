using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;

namespace ItecDashManager.Domain.Interfaces.ServiceInterfaces;

    public interface IUserService
    {
        Task<User> AuthenticateAsync(string email, string password);
        object GetTokenData(User user);
    }

