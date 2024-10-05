using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.InterfaceService;
using TaskManagement.Application.InterfacesRepository;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Models;

namespace TaskManagement.Tests
{
    public class TaskServiceTests
    {

        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly ITaskService _taskService;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _taskService = new TaskService(_taskRepositoryMock.Object);
        }


        [Fact]
        public async System.Threading.Tasks.Task AddTask_LimitTask_Exception()
        {
            var project = new Project { Id = 1, Tasks = new List<Domain.Models.Task>(new Domain.Models.Task[20]) };
            _projectRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(project);

            var tarefa = new Domain.Models.Task { Project = project, ProjectId = 1 };

            var exception = await Assert.ThrowsAsync<Exception>(() => _taskService.AddTask(tarefa));
            Assert.Equal("Limite de 20 tarefas por projeto atingido.", exception.Message);
        }

   
    }
}
