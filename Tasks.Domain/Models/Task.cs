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
        public Status Status { get; set; } 
        public int ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Project Project { get; set; }
        public ICollection<History> Histories { get; set; } = new List<History>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

      
        public void Update(string description, string status, int userId)
        {
            Histories.Add(new History
            {
                Description = $"Updated from '{Description}' to '{description}' and status to '{status}'",
                ChangeDate = DateTime.UtcNow,
                UserId = userId
            });
            Description = description;
            Status = Status;
        }

        public void AddComment(string comment, int userId)
        {
            Histories.Add(new History
            {
                Description = $"Comment added: '{comment}'",
                ChangeDate = DateTime.UtcNow,
                UserId = userId
            });
        }

        public void SetPriority(Priority priority)
        {
            if (Priority == 0) 
                Priority = priority;
            else
                throw new InvalidOperationException("A prioridade não pode ser alterada após a criação.");
        }



    }
}
