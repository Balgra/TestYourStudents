using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;

namespace TestYourStudents.Tests.MockRepositories
{
    public class TestRepository<T>: IRepository<T> where T : BaseEntity
    {
        private List<T> Items { get; }

        public TestRepository(List<T> items)
        {
            Items = items;
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            await Task.Run(() => { });
            return Items;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            await Task.Run(() => { });
            return Items.Find(i => i.Id.Equals(id));
        }

        public async Task<T> AddAsync(T item)
        {
            await Task.Run(() => { });
            Items.Add(item);
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            Items.Remove(item);
        }

        public async Task SaveChangesAsync()
        {
            await Task.Run(() => { });
        }

        public DbSet<T> AsDbSet()
        {
            return null;
        }
    }
}