using scheduleDbLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class ScheduleFacade
    {
        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public ScheduleFacade(string username, string lastname, string firstname)
        {
            Username = username;
            LastName = lastname;
            FirstName = firstname;
        }

        public ScheduleFacade()
        {

        }

        public string GetSchedule(int evenOrOdd, DayOfWeek dayOfWeek)
        {
            var student = new StudentRepo().GetOne(Username, LastName, FirstName);

            if (student == null)
            {
                throw new Exception("Unknown user!");               
            }

            var lessonRepo = new LessonRepo();

            var lesson = string.Join("\n",lessonRepo.GetDailySchedule(evenOrOdd, student.GroupId, dayOfWeek)
                .Select(l=> $"{l.LessonTime}\n{l.Subjects.SubjectName}\n{l.Teachers.TeacherName}\n{l.LessonType}"));

            if (lesson.Equals("") || lesson.Equals(null))
            {
                lesson = lesson = string.Join("\n", lessonRepo.GetDailySchedule(0, student.GroupId, dayOfWeek)
                .Select(l => $"{l.LessonTime}\n{l.Subjects.SubjectName}\n{l.Teachers.TeacherName}\n{l.LessonType}"));
            }


            return lesson == string.Empty || lesson == null ? "Day off" : lesson; // if there is no available schedule that means today is the day off
        }
    }
}
