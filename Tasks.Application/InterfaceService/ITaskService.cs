using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.InterfaceService
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Models.Task>> ListTasksByProject(int projectId);
        Task AddTask(Domain.Models.Task task);
        Task UpdateTask(Domain.Models.Task task);
        Task RemoveTask(int id);
        Task GetPerformanceReport();
    }
}
