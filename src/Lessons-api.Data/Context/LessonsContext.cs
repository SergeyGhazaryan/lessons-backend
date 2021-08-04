using Lessons_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lessons_api.Data.Context
{
    public class LessonsContext : DbContext
    {
        public LessonsContext(DbContextOptions<LessonsContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<TeacherEntity> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<StudentEntity>().ToTable("Students");

            modelBuilder.Entity<TeacherEntity>().ToTable("Teachers");
        }
    }
}
