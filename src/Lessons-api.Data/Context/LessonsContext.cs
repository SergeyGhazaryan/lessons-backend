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

        public DbSet<LessonEntity> Lessons { get; set; }

        public DbSet<StudentLessonRel> StudentLessonRels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<StudentEntity>(entity => entity.HasIndex(s => s.UserId).IsUnique());
            modelBuilder.Entity<StudentEntity>().ToTable("Students");

            modelBuilder.Entity<TeacherEntity>(entity => entity.HasIndex(s => s.UserId).IsUnique());
            modelBuilder.Entity<TeacherEntity>().ToTable("Teachers");

            modelBuilder.Entity<LessonEntity>().ToTable("Lessons");

            modelBuilder.Entity<StudentLessonRel>()
                        .HasOne(scr => scr.Student)
                        .WithMany(s => s.StudentLessonRels)
                        .HasForeignKey(scr => scr.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentLessonRel>()
                        .HasOne(scr => scr.Lesson)
                        .WithMany(s => s.StudentLessonRels)
                        .HasForeignKey(scr => scr.LessonId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
