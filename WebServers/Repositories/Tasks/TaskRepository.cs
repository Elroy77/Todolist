using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServers.Data;

namespace WebServers.Repositories.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodolistDbContext _context;
        public TaskRepository(TodolistDbContext context)
        {
            _context = context;
        }    
        public async Task<IEnumerable<Entities.Task>> GetTaskList()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task<Entities.Task> GetById(Guid Id)
        {
            return await _context.Tasks.FindAsync(Id);
        }
        public async Task<Entities.Task> Create(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
