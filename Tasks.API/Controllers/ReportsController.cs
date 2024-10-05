using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.InterfaceService;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ITaskService _taskService;

        public ReportsController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet("performance")]
        public async Task<ActionResult<IEnumerable<Domain.Models.Task>>> GetPerformanceReport() =>
           Ok(_taskService.GetPerformanceReport());
    }
}
