using Microsoft.EntityFrameworkCore;
using ProjectX.DAL.EF;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Repositories
{
    internal class StudentRepository : IRepository<Student>
    {
        private Context db;

        public StudentRepository()
        {
            db = new Context();
        }
        public void Create(Student item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            Student? student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
            }
           
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Student> GetAll()
        {
             return db.Students;
        }

        public Student? GetOne(int id)
        {
            return db.Students.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
