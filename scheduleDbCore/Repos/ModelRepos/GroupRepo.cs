using scheduleDbCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbCore.Repos
{
    public class GroupRepo : BaseRepo<Group>
    {
        //overoads GetOne method to get record by its name

        public List<Group> GetAll(int facultyId) => Context.Groups.Where(g => g.FacultyId.Equals(facultyId)).Select(g => g).ToList();

        public Group GetOne(string groupName)
        {
            return Context.Groups.Where(g => g.GroupName.Equals(groupName)).Select(g => g).FirstOrDefault();
        }
    }
}
