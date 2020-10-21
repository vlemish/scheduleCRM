using scheduleDbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbLayer.Repos
{
    public class LessonRepo : BaseRepo<Lesson>
    {
        public List<Lesson> GetDailySchedule(int evenOrOdd, int groupId, DayOfWeek dayOfWeek) => Context.Lessons.
            Where(l => l.EvenOrOdd == evenOrOdd && l.GroupId == groupId && l.DayOfWeek == dayOfWeek).
            Select(l => l).ToList();

        public List<Lesson> GetAllLessons(int subjectId) => Context.Lessons
            .Where(l => l.SubjectId.Equals(subjectId))
            .Select(l => l).ToList();
    }
}
