using Microsoft.EntityFrameworkCore;
using TestYourStudents.Core.Entities;

namespace TestYourStudents.EF
{
    public class TestYourStudentsDbContext : DbContext
    {
        public TestYourStudentsDbContext(DbContextOptions<TestYourStudentsDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Professor> Professor { get; set; }
    }
}