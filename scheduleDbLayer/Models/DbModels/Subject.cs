using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace scheduleDbLayer.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
        }

        public Subject()
        {
                
        }

        public virtual ICollection<SubjectTeachers> SubjectTeachers { get; set; }

        public virtual ICollection<GroupSubjects> GroupSubjects { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
