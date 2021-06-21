using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebModels.TaskRequest;
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
        public async Task<IActionResult> GetAllTask([FromQuery] TaskListSearch taskListSearch)
        {
            var tasks = await _taskRepository.GetTaskList(taskListSearch);
            var TaskDTOs = tasks.Select(x => new TaskDTO()
            {
                Status = x.Status,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreateDate = x.CreateDate,
                Priority = x.Priority,
                Id = x.Id,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });
            return Ok(TaskDTOs);
        }

        // api/tasks/{id}
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var tasks = await _taskRepository.GetById(Id);
            if (tasks == null) return NotFound($"{Id} is not found");
            return Ok(new TaskDTO()
            {
                Name = tasks.Name,
                Status = tasks.Status,
                Priority = tasks.Priority,
                Id = tasks.Id,
                AssigneeId = tasks.AssigneeId,
                CreateDate = tasks.CreateDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var task = await _taskRepository.Create(new Entities.Task()
            {
                Name = request.Name,
                Priority = request.Priority,
                Status = WebModels.Enums.Status.Open,
                CreateDate = DateTime.Now,
                Id = request.Id
            });
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var taskFromDb = await _taskRepository.GetById(Id);
            if (taskFromDb == null)
            {
                return NotFound($"{Id} is not found");
            }
            taskFromDb.Name = request.Name;
            taskFromDb.Status = request.Status;
            taskFromDb.Priority = request.Priority;
            var taskResult = await _taskRepository.Update(taskFromDb);
            return Ok(new TaskDTO()
            {
                Name = taskResult.Name,
                Status = taskResult.Status,
                Priority = taskResult.Priority,
                Id = taskResult.Id,
                AssigneeId = taskResult.AssigneeId,
                CreateDate = taskResult.CreateDate
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");

            await _taskRepository.Delete(task);
            return Ok(new TaskDTO()
            {
                Name = task.Name,
                Status = task.Status,
                Id = task.Id,
                AssigneeId = task.AssigneeId,
                Priority = task.Priority,
                CreateDate = task.CreateDate
            });
        }
    }
}
