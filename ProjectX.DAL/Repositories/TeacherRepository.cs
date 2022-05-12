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
    public class TeacherRepository : IRepository<Teacher>
    {
        private Context db;

        public TeacherRepository()
        {
            db = new Context();
        }
        public void Create(Teacher item)
        {
            db.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            Teacher? teacher = db.Teachers.Find(id);
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
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

        public IEnumerable<Teacher> GetAll()
        {
            return db.Teachers;
        }

        public Teacher? GetOne(int id)
        {
            return db.Teachers.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Teacher item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

