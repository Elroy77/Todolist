using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebServers.Entities;
using WebServers.Data;
using Microsoft.EntityFrameworkCore;

namespace WebServers.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly TodolistDbContext _context;
        public UserRepository(TodolistDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
