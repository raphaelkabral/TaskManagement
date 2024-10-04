using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

        public void AddTask(Task task)
        {
            if (Tasks.Count >= 20)
                throw new InvalidOperationException("Limite de 20 tarefas por projeto atingido.");
            Tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }

        public bool HasPendingTasks() => Tasks.Any(t => t.Status == Enums.Status.Pending);
    }
}
