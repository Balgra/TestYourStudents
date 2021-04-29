using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestYourStudents.EF.EFRepositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T obj);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}