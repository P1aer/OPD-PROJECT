using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Repositories;
using ProjectX.Logic.DTO;
using System.Xml.Linq;

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
                Name = lecture.Name,
                TeacherID = lecture.TeacherID,
            };
            repository.Create(std);
            repository.Save();
        }
        public string? Report(LectureReportDTO lecture, string format)
        {
            var lec = (repository.GetAll() as DbSet<Lecture>)
                .Include(l => l.Students)
                .Include(l => l.Homework.Students)
                .FirstOrDefault(l => l.Name == lecture.Name);
            if (lec != null)
            {
                switch (format)
                {
                    case "xml":
                       return XmlReport(lec);
                    case "json":
                        return JsonReport(lec);                   
                    default:
                        return null;
                }
            }
            return null;
        }
        private string XmlReport(Lecture lec)
        {
           var x = new XElement("Lecture",
               new XElement("Name",lec.Name),
               new XElement("ID", lec.ID),
               new XElement("Teacher", 
                    new XElement("Name",lec.Teacher.Name),
                    new XElement("SurName",lec.Teacher.SurName)
                    ),
               new XElement("HomeWork", lec.Homework.Task),
               new XElement("Date", lec.Date),
               new XElement("Attendance", 
               from st in lec.Attendances
               select new XElement("Student", 
                    new XElement("StudentId",st.LectureId),
                    new XElement("OnLecture", st.onLection))),
               new XElement("Homeworks", from hm in lec.Homework.Grades 
                   select new XElement("Homework",    
                     new XElement("StudentId",hm.StudentId),
                     new XElement("Mark",hm.Mark))
                   )
               );
            return x.ToString();

        }
        private string JsonReport(Lecture lec)
        {
            /*            string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);*/
            string s = JsonConvert.SerializeObject(lec, Formatting.Indented);
            return s;
            /* File.WriteAllText(desk + @"\"+ std.Name +".json", s);*/

        }
/*        public List<Student> checkAttendance()
        {
            var lec = (repository.GetAll() as DbSet<Lecture>)
             .Include(l => l.Students);
            List<Student> res = new List<Student>();
            foreach(var l in lec)
            {
                foreach(var s in l.Students)
                {
                    var times = l.Attendances.Count(x => x.onLection == false && x.StudentId == s.ID);
                    *//*
                     * функцмонал рассылки на мыло в контроллере 
                     *//*
                    if (times > 3)
                    {
                        res.Add(s);
                    }
                }
            }
            return res;
        }*/
        public void Update(LectureDTO lecture)
        {
            Lecture std = new Lecture
            {
                ID = lecture.ID,
                Name = lecture.Name,
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
