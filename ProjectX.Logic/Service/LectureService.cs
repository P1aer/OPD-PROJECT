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
    public class LectureService
    {
        LectureRepository repository { get; set; }

        public LectureService(LectureRepository context)
        {
            repository = context;
        }
        public Lecture? GetOne(int id)
        {
            return repository.GetOne(id);
        }
        public List<Lecture> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public void Create(LectureDTO lecture)
        {
            Lecture std = new Lecture
            {
                ID = lecture.ID,
                Date =lecture.Date,
                TeacherID = lecture.TeacherID,
            };
            repository.Create(std);
            repository.Save();
        }
        public void Update(LectureDTO lecture)
        {
            Lecture std = new Lecture
            {
                ID = lecture.ID,
                Date = lecture.Date,
                TeacherID = lecture.TeacherID,
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
