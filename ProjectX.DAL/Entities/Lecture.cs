using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Entities
{
    public class Lecture
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Date { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Attendance> Attendances  { get; set; } = new List<Attendance>();
        public int HomeworkId { get; set; }
        public Homework Homework { get; set; }
    }
}
