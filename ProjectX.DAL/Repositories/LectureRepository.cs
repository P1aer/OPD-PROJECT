using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.DAL.EF;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.Repositories
{
    public class LectureRepository : IRepository<Lecture>
    {
        private Context db;

        public LectureRepository()
        {
            db = new Context();
        }
        public void Create(Lecture item)
        {
            db.Lectures.Add(item);
        }

        public void Delete(int id)
        {
            Lecture? lecture = db.Lectures.Find(id);
            if (lecture != null)
            {
                db.Lectures.Remove(lecture);
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

        public IEnumerable<Lecture> GetAll()
        {
            return db.Lectures;
        }

        public Lecture? GetOne(int id)
        {
            return db.Lectures.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Lecture item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
