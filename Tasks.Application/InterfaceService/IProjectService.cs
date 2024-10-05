using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.InterfaceService
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListProjects();
        System.Threading.Tasks.Task AddProject(Project projeto);
        System.Threading.Tasks.Task RemoveProject(int id);
    }
}
