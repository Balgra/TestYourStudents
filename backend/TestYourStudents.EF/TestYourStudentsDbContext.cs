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

        public DbSet<StudentEmail> StudentEmail { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionResponse> QuestionResponse { get; set; }
        public DbSet<QuizGrade> QuizGrade { get; set; }
        public DbSet<QuizSession> QuizSession { get; set; }
        public DbSet<QuizSubmission> QuizSubmission { get; set; }
    }
}