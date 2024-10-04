﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class History
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime ChangeDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
