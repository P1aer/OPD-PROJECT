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

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Date { get; set; }
/*        public Dictionary<Student, bool> attendance { get; set; }

        public List<Homework> homeworks { get; set; }*/
   
    }
}
