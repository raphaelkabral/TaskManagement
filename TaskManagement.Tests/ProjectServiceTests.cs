using Moq;
using TaskManagement.Application.InterfaceService;
using TaskManagement.Application.InterfacesRepository;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Models;
using Tasks.Infrastructure;

namespace TaskManagement.Tests
{

    public class ProjectServiceTests
    {

        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly IProjectService _projectService;

        public ProjectServiceTests()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectService = new ProjectService(_projectRepositoryMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task AddProject_ShouldCallAddProjectAsync()
        {
            // Arrange
            var project = new Project { Name = "Novo Projeto" };

            // Act
            await _projectService.AddProject(project);

            // Assert
            _projectRepositoryMock.Verify(x => x.AddAsync(project), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveProject__WhenIdIsNegative_ThrowsArgumentException()
        {
            // Arrange
            var project = new Project { Id = 1, Tasks = new List<Domain.Models.Task> { new Domain.Models.Task { Status = Domain.Enums.Status.Pending } } };
            _projectRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(project);

            var exception = await Assert.ThrowsAsync<Exception>(() => _projectService.RemoveProject(1));
            Assert.Equal("Não é possível remover o projeto com tarefas pendentes.", exception.Message);
        }

         [Fact]
        public async System.Threading.Tasks.Task RemoveProject__WhenValidId()
        {
            // Arrange
            var project = new Project { Id = 1, Tasks = new List<Domain.Models.Task> { new Domain.Models.Task { Status = Domain.Enums.Status.Completed } } };
            _projectRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(project);

            // Act
            await _projectService.RemoveProject(1);

            // Assert
            _projectRepositoryMock.Verify(r => r.RemoveAsync(project), Times.Once);
        }

    }


}