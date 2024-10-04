using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.InterfacesRepository;
using TaskManagement.Domain.Models;
using Tasks.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repository
{
    public  class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync() =>
        await _context.Projects.ToListAsync();

        public async Task<Project> GetByIdAsync(int id) =>
        await _context.Projects.FindAsync(id);

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var project = await GetByIdAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
