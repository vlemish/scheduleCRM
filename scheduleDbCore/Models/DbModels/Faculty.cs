using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scheduleDbCore.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FacultyName { get; set; }

        public Faculty(string facultyName)
        {
            FacultyName = facultyName;
        }

        public Faculty() { }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
