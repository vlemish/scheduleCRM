using scheduleDbCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbCore.Repos
{
    public class FacultyRepo : BaseRepo<Faculty>
    {

        public Faculty GetOne(string facultyName)
        {
            return Context.Faculties.Where(f => f.FacultyName.Equals(facultyName)).Select(f => f).FirstOrDefault();
        }

        public override List<Faculty> GetAll()
        {
            return Context.Faculties.ToList();
        }
    }
}
