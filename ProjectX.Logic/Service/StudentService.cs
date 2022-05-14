using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using ProjectX.Logic.DTO;
using System.Xml.Linq;

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
                Email = student.Email,
                SurName = student.SurName,
                MidName = student.MidName,
            };
            repository.Create(std);
            repository.Save();
        }
        public string? Report(StudentReportDTO user, string format)
        {
            var student = (repository.GetAll() as DbSet<Student>)
                .Include(s => s.Lectures)
                .Include(s => s.Homeworks)
                .FirstOrDefault( s => s.Name == user.Name && s.MidName == user.MidName && s.SurName == user.SurName);
            if (student != null)
            {
                switch(format)
                {
                    case "xml":
                        return XmlReport(student);
                    case "json":
                        return JsonReport(student);
                    default:
                        return null;
                }
            }
            return  null;
        }
        private string XmlReport(Student std)
        {
/*          string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);*/
     
           var x = new XElement("Student",
               new XElement("Name",std.Name),
               new XElement("ID", std.ID),
               new XElement("MidName", std.MidName),
               new XElement("SurName", std.SurName),
               new XElement("Email", std.Email),
               new XElement("Attendance", 
               from at in std.Attendances
               select new XElement("Lecture", 
                    new XElement("LectureId",at.LectureId),
                    new XElement("OnLecture", at.onLection))),
               new XElement("Homeworks", from hm in std.Grades 
                   select new XElement("Homework",
                     new XElement("HomeworkId",hm.HomeworkId),
                     new XElement("Mark",hm.Mark))
                   )
               );
            return x.ToString();

        }
        private string JsonReport(Student std)
        {
/*            string desk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);*/
            string s = JsonConvert.SerializeObject(std, Formatting.Indented);
            return s;
           /* File.WriteAllText(desk + @"\"+ std.Name +".json", s);*/
        }
        public List<Student> checkAttendance()
        {
            var std = (repository.GetAll() as DbSet<Student>)
             .Include(l => l.Lectures);
            List<Student> res = new List<Student>();
            foreach (var s in std)
            {
                    var times = s.Attendances.Count(x => x.onLection == false && x.StudentId == s.ID);
                    /*
                     * функцмонал рассылки на мыло в контроллере 
                     */
                    if (times > 3)
                    {
                        res.Add(s);
                   }
            }
            return res;
        }
        public List<Student> endOfCourse()
        {
            var std = (repository.GetAll() as DbSet<Student>)
            .Include(l => l.Homeworks);
            List<Student> res = new List<Student>();
            foreach (var s in std)
            {
                var sum = s.Grades.Where(x => x.StudentId == s.ID).Sum(x => x.Mark);
                    if (sum != null)
                    {
                        var mark =  (double) sum/ (double)s.Grades.Count(x => x.StudentId == s.ID);                
                        if (mark < 4)
                        {
                            res.Add(s);
                        }
                    }
                    else
                    {
                        res.Add(s);
                    }
   
                /*
                 * функцмонал рассылки смс в контроллере 
                 */
            }
            return res;
        }
        public void Update(StudentDTO student)
        {
            Student std = new Student
            {
                ID = student.ID,
                Name = student.Name,
                Email = student.Email,
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
