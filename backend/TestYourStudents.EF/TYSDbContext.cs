using Microsoft.EntityFrameworkCore;

namespace TestYourStudents.EF
{
    public class TYSDbContext :DbContext
    {
        public TYSDbContext(DbContextOptions<TYSDbContext> options) : base(options)
        {
            
        }
    }
}