using ExamProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Infrastructure.Data {

    public class ExamDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int> {
        public virtual DbSet<ExamEntity> Exams { get; set; }

        public ExamDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<UserExamEntity>().Property(x => x.IsCompleted).HasDefaultValue(false);
            builder.Entity<ExamEntity>().Property(x => x.EndTime).HasComputedColumnSql("[StartTime] + [Duration] Period");
        }
    }
}