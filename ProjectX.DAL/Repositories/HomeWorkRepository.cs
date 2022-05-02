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
    internal class HomeWorkRepository: IRepository<Homework>
    {
        private Context db;

        public HomeWorkRepository()
        {
            db = new Context();
        }
        public void Create(Homework item)
        {
            db.Homeworks.Add(item);
        }

        public void Delete(int id)
        {
            Homework? work = db.Homeworks.Find(id);
            if (work != null)
            {
                db.Homeworks.Remove(work);
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

        public IEnumerable<Homework> GetAll()
        {
            return db.Homeworks;
        }

        public Homework? GetOne(int id)
        {
            return db.Homeworks.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Homework item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
