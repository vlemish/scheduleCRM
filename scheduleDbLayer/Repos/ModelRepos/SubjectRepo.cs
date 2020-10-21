using scheduleDbLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbLayer.Repos
{
    public class SubjectRepo : BaseRepo<Subject>
    {
        public Subject GetOne(string subjectName)
        {
            return Context.Subjects.Where(s => s.SubjectName.Equals(subjectName)).Select(s => s).FirstOrDefault();
        }

        public List<Subject> GetAllSubjectsAssociatedWithGroup(int groupId)
        {
            return Context.GroupSubjects.Where(gs => gs.GroupId.Equals(groupId)).Select(gs => gs.Subject).ToList();
        }
    }
}
