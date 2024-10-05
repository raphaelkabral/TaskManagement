using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.InterfaceService;
using TaskManagement.Application.Services;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{projetoId}")]
        public async Task<ActionResult<IEnumerable<Domain.Models.Task>>> GetTasks(int projectId) =>
            Ok(await _taskService.ListTasksByProject(projectId));

        [HttpPost]
        public async Task<ActionResult> PostTarefa([FromBody] Domain.Models.Task task)
        {
            await _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTasks), new { projetoId = task.ProjectId }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTarefa(int id, [FromBody] Domain.Models.Task task)
        {
            task.Id = id;
            await _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            await _taskService.RemoveTask(id);
            return NoContent();
        }
    }
}
