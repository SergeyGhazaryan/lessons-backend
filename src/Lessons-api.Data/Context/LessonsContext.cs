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

        public DbSet<TeacherStudentRel> TeacherStudentRels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<StudentEntity>(entity => entity.HasIndex(s => s.UserId).IsUnique());
            modelBuilder.Entity<StudentEntity>().ToTable("Students");

            modelBuilder.Entity<TeacherEntity>(entity => entity.HasIndex(s => s.UserId).IsUnique());
            modelBuilder.Entity<TeacherEntity>().ToTable("Teachers");

            modelBuilder.Entity<TeacherStudentRel>()
                        .HasOne(tsr => tsr.Teacher)
                        .WithMany(t => t.TeacherStudentRels)
                        .HasForeignKey(tsr => tsr.TeacherId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherStudentRel>()
                        .HasOne(tsr => tsr.Student)
                        .WithMany(s => s.TeacherStudentRels)
                        .HasForeignKey(tsr => tsr.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
