using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool Completed { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Project Project { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<History> Histories { get; set; } = new List<History>();

        public void SetPriority(Priority priority)
        {
            if (priority != 0) // Se já tiver prioridade definida
                throw new InvalidOperationException("Não é permitido alterar a prioridade da tarefa.");

            Priority = priority;
        }
    }
}
