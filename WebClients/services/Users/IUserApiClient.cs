using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace WebClients.services.Users
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDTO>> GetAllAssignees();
    }
}
