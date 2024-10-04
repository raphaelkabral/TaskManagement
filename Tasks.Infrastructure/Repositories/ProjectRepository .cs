using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.InterfacesRepository;
using TaskManagement.Domain.Models;
using Tasks.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Repository
{
    public class ProjectRepository : IProjectRepository
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
        public async Task<IEnumerable<Project>> GetAllByUserIdAsync(int userId) =>
            await _context.Projects.Where(p => p.UserId == userId).ToListAsync();

        public async Task AddAsync(Project project) => await _context.Projects.AddAsync(project);
        public async Task RemoveAsync(Project project) => _context.Projects.Remove(project);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();


    }
}
