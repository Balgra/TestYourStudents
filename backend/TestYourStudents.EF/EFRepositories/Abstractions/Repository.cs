using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestYourStudents.EF.EFRepositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TestYourStudentsDbContext _context = null;
        private DbSet<T> table = null;
        public Repository(TestYourStudentsDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }
        
        public async Task<T> AddAsync(T obj)
        {
            return (await table.AddAsync(obj)).Entity;
        }
        
        public async Task DeleteAsync(int id)
        {
            T existing = await GetByIdAsync(id);
            table.Remove(existing);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}