using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.InterfacesRepository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        System.Threading.Tasks.Task AddAsync(Project project);
        System.Threading.Tasks.Task RemoveAsync(int id);
    }
}
