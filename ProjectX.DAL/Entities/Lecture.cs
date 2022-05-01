using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Entities
{
    internal class Lecture
    {
        public int LectureID { get; set; }

        public int TeacherTeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public DateTime Date { get; set; }
    }
}
