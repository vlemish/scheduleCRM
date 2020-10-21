using scheduleDbLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer
{
    public class SubjectFacade
    {
        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public SubjectFacade(string username, string lastname, string firstname)
        {
            Username = username;
            LastName = lastname;
            FirstName = firstname;
        }

        public SubjectFacade()
        {

        }

        public string GetSubjects(int subjectId)
        {

            var subject = new SubjectRepo().GetOne(subjectId);

            var teacher = new SubjectTeachersRepo().GetAllAssociatedTeachers(subjectId).FirstOrDefault().TeacherName;

            return $"{subject.SubjectName}\n{teacher}";
        }

    }
}
