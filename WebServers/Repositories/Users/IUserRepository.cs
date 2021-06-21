using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebServers.Entities;

namespace WebServers.Repositories.Users
{
    public interface IUserRepository
    {
        public Task <List<User>> GetUserList();
    }
}
