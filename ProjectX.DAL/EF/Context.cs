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

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
