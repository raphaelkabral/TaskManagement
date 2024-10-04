﻿using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjetos() =>
            Ok(await _projectService.ListProjects());

        [HttpPost]
        public async Task<ActionResult> PostProjeto([FromBody] Project project)
        {
            await _projectService.CreateProject(project);
            return CreatedAtAction(nameof(GetProjetos), new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjeto(int id)
        {
            await _projectService.RemoveProject(id);
            return NoContent();
        }
    }
}
