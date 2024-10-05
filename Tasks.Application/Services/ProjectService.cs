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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> ListProjects() =>
            await _projectRepository.GetAllAsync();

        public async System.Threading.Tasks.Task AddProject(Project projeto) =>
            await _projectRepository.AddAsync(projeto);

        public async System.Threading.Tasks.Task RemoveProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                throw new Exception("Projeto não encontrado.");

            if (project.Tasks.Any(x => x.Status == Domain.Enums.Status.Pending))
                throw new Exception("Não é possível remover o projeto com tarefas pendentes.");

            await _projectRepository.RemoveAsync(project);
        }
    }
}
