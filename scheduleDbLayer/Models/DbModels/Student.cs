using System;
using System.Collections.Generic;
using System.Text;

namespace scheduleDbLayer.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Student(string firstName, string lastName, string username, int facultyId, int groupId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            FacultyId = facultyId;
            GroupId = groupId;
        }

        public Student()
        {

        }


        //FK_FacultyToStudent
        public int FacultyId { get; set; }
        public Faculty Faculties { get; set; }

        //FK_GroupToStudent
        public int GroupId { get; set; }
        public Group Groups { get; set; }

    }
}
