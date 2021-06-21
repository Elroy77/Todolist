using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServers.Repositories.Users;
using WebModels;

namespace WebServers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        // api/users/
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userRepository.GetUserList();
            var userDTOs = users.Select(x => new AssigneeDTO()
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName
            });
            return Ok(userDTOs);
        }
    }
}
