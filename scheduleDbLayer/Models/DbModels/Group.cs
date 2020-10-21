using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbLayer.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }
        
        //FK_FacultyToGroup
        public int FacultyId { get; set; }

        public Group(string groupName, int facultyId)
        {
            GroupName = groupName;
            FacultyId = facultyId;
        }

        public Group()
        {

        }


        public Faculty Faculties { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<GroupSubjects> GroupSubjects { get; set; }

    }
}
