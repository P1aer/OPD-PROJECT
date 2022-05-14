using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Entities
{
   public class Student
    {
        public int ID { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string? MidName { get; set; } 
        public string Email { get; set; }

        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

        public List<Homework> Homeworks { get; set; } = new List<Homework>();
        public List<Grade> Grades { get; set; } = new List<Grade> ();
       
    }
}
