using System.ComponentModel.DataAnnotations.Schema;

namespace scheduleDbCore.Models
{
    public class SubjectTeachers
    {
        public SubjectTeachers(int teacherId, int subjectId)
        {
            TeacherId = teacherId;
            SubjectId = subjectId;
        }

        public SubjectTeachers() { }



        //[Key, Column(Order = 1)]
        public int SubjectId { get; set; }

        //[Key, Column(Order = 2)]
        public int TeacherId { get; set; }

        public Subject Subject { get; set; }

        public Teacher Teacher { get; set; }

        [NotMapped]
        public int Id { get; set; }
    }
}
