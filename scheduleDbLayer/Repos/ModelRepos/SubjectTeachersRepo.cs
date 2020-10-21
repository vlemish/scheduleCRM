using scheduleDbLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbLayer.Repos
{
    public class SubjectTeachersRepo : BaseRepo<SubjectTeachers>
    {
        public List<Subject> GetAllAssociatedSubjects(int teacherId) => Context.SubjectTeachers.Where(st => st.TeacherId.Equals(teacherId)).Select(st => st.Subject).ToList();

        public List<Teacher> GetAllAssociatedTeachers(int subjectId) => Context.SubjectTeachers.Where(st => st.SubjectId.Equals(subjectId)).Select(st => st.Teacher).ToList();

    }
}
