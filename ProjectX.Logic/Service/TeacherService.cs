using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Repositories;
using ProjectX.Logic.DTO;

namespace ProjectX.Logic.Service
{
    public class TeacherService
    {
        TeacherRepository repository { get; set; }

        public TeacherService(TeacherRepository context)
        {
            repository = context;
        }
        public Teacher? GetOne(int id)
        {
            return repository.GetOne(id);
        }
        public List<Teacher> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public void Create(TeacherDTO teacher)
        {
            Teacher std = new Teacher
            {
                ID = teacher.ID,
                Name = teacher.Name,
                Email = teacher.Email,
                MidName = teacher.MidName,
                SurName = teacher.SurName,
            };
            repository.Create(std);
            repository.Save();
        }
        public void Update(TeacherDTO teacher)
        {
            Teacher std = new Teacher
            {
                ID = teacher.ID,
                Name = teacher.Name,
                Email= teacher.Email,
                MidName = teacher.MidName,
                SurName = teacher.SurName,
            };
            repository.Update(std);
            repository.Save();
        }
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
