using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Application.InterfacesRepository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();      
        Task<IEnumerable<Project>> GetAllByUserIdAsync(int userId);
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task RemoveAsync(Project project);

        //System.Threading.Tasks.Task RemoveAsync(int id);

       
    }
}
