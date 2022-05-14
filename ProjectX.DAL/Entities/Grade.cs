using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.DAL.Entities
{
    public class Grade
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int HomeworkId { get; set; }
        public Homework Homework { get; set; }
        public ushort? Mark { get; set; }
    }
}
