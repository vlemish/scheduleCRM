using System.ComponentModel.DataAnnotations.Schema;

namespace scheduleDbCore.Models
{
    public class GroupSubjects
    {
        public GroupSubjects(int groupId, int subejctId)
        {
            GroupId = groupId;
            SubjectId = subejctId;
        }

        public GroupSubjects() { }


        //[Key, Column(Order = 1)]
        public int GroupId { get; set; }

        //[Key, Column(Order = 2)]
        public int SubjectId { get; set; }

        public Group Group { get; set; }

        public Subject Subject { get; set; }
        [NotMapped]
        public int Id { get; set; }
    }
}
