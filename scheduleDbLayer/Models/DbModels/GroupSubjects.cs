using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class GroupSubjects
    {
        public GroupSubjects(int groupId, int subejctId)
        {
            GroupId = groupId;
            SubjectId = subejctId;
        }

        public GroupSubjects()
        {

        }


        [Key, Column(Order = 1)]
        public int GroupId { get; set; }

        [Key, Column(Order = 2)]
        public int SubjectId { get; set; }

        public Group Group  { get; set; }

        public Subject Subject { get; set; }
    }
}
