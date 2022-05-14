using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.DAL.Entities;

namespace ProjectX.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public Context() : this(false) { }
        public Context(bool bFromScratch) : base()
        {
            if (bFromScratch)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OPD;Trusted_connection=TRUE");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // многие ко многим студент - домашка + оценка
            modelBuilder.Entity<Homework>()
                .HasMany(h => h.Students)
                .WithMany(s => s.Homeworks).
                UsingEntity<Grade>(
                j => j.HasOne(pt => pt.Student)
                .WithMany(t => t.Grades)
                .HasForeignKey(pt => pt.StudentId),
                j => j.HasOne(pt => pt.Homework)
                .WithMany(p => p.Grades)
                .HasForeignKey(pt => pt.HomeworkId),
                j =>
                {
                    j.HasKey(t => new { t.HomeworkId, t.StudentId });
                    j.ToTable("Grades");
                });
            // многие ко многим студент лекции + посещение
             modelBuilder.Entity<Lecture>()
                .HasMany(h => h.Students)
                .WithMany(s => s.Lectures).
                UsingEntity<Attendance>(
                j => j.HasOne(pt => pt.Student)
                .WithMany(t => t.Attendances)
                .HasForeignKey(pt => pt.StudentId),
                j => j.HasOne(pt => pt.Lecture)
                .WithMany(p => p.Attendances)
                .HasForeignKey(pt => pt.LectureId),
                j =>
                {
                    j.HasKey(t => new { t.LectureId, t.StudentId });
                    j.ToTable("Attendances");
                });
        }
    }
}
