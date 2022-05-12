using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.DAL.Entities;

namespace ProjectX.Logic.DTO
{
    public class LectureDTO
    {
        public int ID { get; set; }

        public int TeacherID { get; set; }
        public Dictionary<Student, bool> attendance { get; set; }

        public List<Homework> homeworks { get; set; }
    }
}
