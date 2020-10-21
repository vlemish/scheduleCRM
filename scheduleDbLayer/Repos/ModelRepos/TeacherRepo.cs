using scheduleDbLayer.Models;
using System.Linq;

namespace scheduleDbLayer.Repos
{
    public class TeacherRepo : BaseRepo<Teacher>
    {
        public Teacher GetOne(string teacherName)
        {
            return Context.Teachers.Where(t => t.TeacherName.Equals(teacherName)).Select(t => t).FirstOrDefault();
        }
    }
}
