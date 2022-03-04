using CreateExam.Core.Entities.Concrete;
using CreateExam.Infrastructure.Configuration.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreateExam.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        //public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
            //modelBuilder.ApplyConfiguration(new ExamMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}