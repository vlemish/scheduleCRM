using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scheduleDbCore.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string TeacherName { get; set; }

        public Teacher(string teacherName)
        {
            TeacherName = teacherName;
        }

        public Teacher() { }


        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<SubjectTeachers> SubjectTeachers { get; set; }
    }
}
