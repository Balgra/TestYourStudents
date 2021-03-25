using Microsoft.EntityFrameworkCore;

namespace TestYourStudents.EF
{
    public class TestYourStudentsDbContext : DbContext
    {
        public TestYourStudentsDbContext(DbContextOptions<TestYourStudentsDbContext> options)
            : base(options)
        {
            
        }
    }
}