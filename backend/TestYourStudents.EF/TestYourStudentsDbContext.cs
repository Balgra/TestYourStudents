using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestYourStudents.Core.Entities;

namespace TestYourStudents.EF
{
    public class TestYourStudentsDbContext : IdentityDbContext<User>
    {
        public TestYourStudentsDbContext(DbContextOptions<TestYourStudentsDbContext> options)
            : base(options)
        {
            
        }
    }
}