using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.InterfacesRepository;
using Tasks.Infrastructure;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllTasks() =>
        await _context.Tasks.ToListAsync();

        public async Task<IEnumerable<Domain.Models.Task>> GetByProjectIdAsync(int projectId) =>
            await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();

        public async System.Threading.Tasks.Task AddAsync(Domain.Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Models.Task> GetByIdAsync(int id) =>
            await _context.Tasks.FindAsync(id);

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Models.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveAsync(int id)
        {
            var task = await GetByIdAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }


    }
}
