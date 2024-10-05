using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.InterfaceService;
using TaskManagement.Application.InterfacesRepository;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Models.Task>> ListTasksByProject(int projectId) =>
            await _taskRepository.GetByProjectIdAsync(projectId);

        public async System.Threading.Tasks.Task AddTask(Domain.Models.Task task)
        {        

            if (task.Project.Tasks.Count >= 20)
                throw new Exception("Limite de 20 tarefas por projeto atingido.");
            task.SetPriority(task.Priority);
            await _taskRepository.AddAsync(task);
        }

        public async System.Threading.Tasks.Task UpdateTask(Domain.Models.Task task)
        {
            var existingTask = await _taskRepository.GetByIdAsync(task.ProjectId);

            existingTask.Histories.Add(new History
            {
                Description = "Updated task details.",
                ChangeDate = DateTime.UtcNow,
                UserId = 00 
            });

            task.Priority = existingTask.Priority;
            await _taskRepository.UpdateAsync(existingTask);
        }

        public async System.Threading.Tasks.Task RemoveTask(int id) =>
            await _taskRepository.RemoveAsync(id);

        public async System.Threading.Tasks.Task GetPerformanceReport()
        {
            var tasks = await _taskRepository.GetAllTasks();

            var report = tasks.Where(t => t.Status == Domain.Enums.Status.Completed && t.CreatedAt >= DateTime.UtcNow.AddDays(-30))
                .GroupBy(t => t.Project.UserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    AverageTasksCompleted = g.Count() / 30
                }).ToList();
        }

    }
}
