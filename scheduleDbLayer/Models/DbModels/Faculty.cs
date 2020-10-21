using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public Faculty(string facultyName)
        {
            FacultyName = facultyName;
        }

        public Faculty()
        {

        }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Group> Groups{ get; set; }
    }
}
