using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Entities
{
    internal class Homework
    {
        public int HomeworkID { get; set; }

        public short? Grade { get; set; }

        public int StudentStudentID { get; set; }
        public Student Student { get; set; }

        public int LectureLectureID { get; set; }
        public Lecture Lecture { get; set; }
    }
}
