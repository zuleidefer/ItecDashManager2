using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ItecDashManager.Data.Repositories;

public class UserRepository : IUserRepository

{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetOneByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}

