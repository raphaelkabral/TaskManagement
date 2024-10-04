using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
