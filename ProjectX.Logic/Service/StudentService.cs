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
   
    public class StudentService
    {
         StudentRepository repository { get; set; }

        public StudentService(StudentRepository context)
        {
            repository = context;
        }
        public Student? GetOne(int id)
        {
            return repository.GetOne(id);
        }
        public List<Student> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public void Create(StudentDTO student)
        {
            Student std = new Student
            {
                ID = student.ID,
                Name = student.Name,
                SurName = student.SurName,
                MidName = student.MidName,
            };
            repository.Create(std);
            repository.Save();
        }
        public void Update(StudentDTO student)
        {
            Student std = new Student
            {
                ID = student.ID,
                Name = student.Name,
                SurName = student.SurName,
                MidName = student.MidName,
            };
            repository.Update(std);
            repository.Save();
        }
        public void Delete (int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
