using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.InterfacesRepository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Domain.Models.Task>> GetAllTasks();
        Task<IEnumerable<Domain.Models.Task>> GetByProjectIdAsync(int projetoId);
        System.Threading.Tasks.Task AddAsync(Domain.Models.Task tarefa);
        System.Threading.Tasks.Task<Domain.Models.Task> GetByIdAsync(int id);
        System.Threading.Tasks.Task UpdateAsync(Domain.Models.Task task);
        System.Threading.Tasks.Task RemoveAsync(int id);
    }
}
