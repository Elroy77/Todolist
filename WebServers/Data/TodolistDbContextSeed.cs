using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Enums;

namespace WebServers.Data
{
    public class TodolistDbContextSeed
    {
        private readonly IPasswordHasher<Entities.User> passwordHasher = new PasswordHasher<Entities.User>();

        public async Task SeedAsync(TodolistDbContext context, ILogger<TodolistDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new Entities.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nguyen",
                    LastName = "Van Manh",
                    Email = "Manhnv.dotnet@gmail.com",
                    PhoneNumber = "0358511226",
                    UserName = "Admin"
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "nvm@error");
                context.Users.Add(user);
            }
            if (!context.Users.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 1",
                    CreateDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }
            await context.SaveChangesAsync();
        }    
    }
}
