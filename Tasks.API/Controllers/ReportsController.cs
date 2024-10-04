using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Controllers
{
    public class ReportsController : Controller
    {
        private readonly TaskService _taskService;

        public ReportsController(TaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet("performance")]
        public async Task<ActionResult<IEnumerable<Domain.Models.Task>>> GetPerformanceReport() =>
           Ok(_taskService.GetPerformanceReport());
    }
}
