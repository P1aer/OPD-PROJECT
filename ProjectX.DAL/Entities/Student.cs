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

    }
}
