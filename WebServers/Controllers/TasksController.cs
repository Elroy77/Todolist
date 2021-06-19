using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServers.Repositories;

namespace WebServers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // api/tasks/
        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var task = await _taskRepository.GetTaskList();
            return Ok(task);
        }

        // api/tasks/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var tasks = await _taskRepository.GetById(id);
            if (tasks == null) return NotFound($"{id} is not found");
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tasks = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id}, tasks);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var taskFromDb = await _taskRepository.GetById(Id);
            if (taskFromDb == null)
            {
                return NotFound($"{Id} is not found");
            }
            taskFromDb.Name = task.Name;
            var tasks = await _taskRepository.Update(task);
            return Ok(tasks);
        }
    }
}
