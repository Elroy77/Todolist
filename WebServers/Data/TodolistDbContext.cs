using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServers.Data
{
    public class TodolistDbContext : IdentityDbContext<Entities.User, Entities.Role, Guid>
    {
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
        {

        }   
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
