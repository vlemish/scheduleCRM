using Microsoft.EntityFrameworkCore;
using scheduleDbCore.Models;
using scheduleDbCore.Models.DbModels;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace scheduleDbCore.EF
{
    public class ScheduleEntities : DbContext
    {
        public ScheduleEntities() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.Local);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<SubjectTeachers> SubjectTeachers { get; set; }

        public DbSet<GroupSubjects> GroupSubjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Unique Constraints         
            //There can't be multiple faculties with the same name
            modelBuilder.Entity<Faculty>()
                .HasIndex(i => i.FacultyName)
                .IsUnique(true);
            //There can't be multiple groups with the same name
            modelBuilder.Entity<Group>()
                .HasIndex(i => i.GroupName)
                .IsUnique(true);
            //There can't be multiple holidays with the same name and date
            modelBuilder.Entity<Holiday>()
                .HasIndex(i => i.HolidayName)
                .IsUnique();
            modelBuilder.Entity<Holiday>()
                .HasIndex(i => i.HolidayDate)
                .IsUnique(true);
            //There can't be multiple subjects with the sama name
            modelBuilder.Entity<Subject>()
                .HasIndex(i => i.SubjectName)
                .IsUnique(true);
            //There can't be multiple teachers with the same name
            modelBuilder.Entity<Teacher>()
                .HasIndex(i => i.TeacherName)
                .IsUnique(true);

            //ONE-TO-MANY
            //FK_GroupToStudent
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Groups)
                .HasForeignKey(s => s.GroupId).OnDelete(DeleteBehavior.NoAction);
            //FK_FacultyToStudent
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Students)
                .WithOne(s => s.Faculties)
                .HasForeignKey(s => s.FacultyId).OnDelete(DeleteBehavior.NoAction);
            //FK_FacultyToGroup
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Groups)
                .WithOne(g => g.Faculties)
                .HasForeignKey(g => g.FacultyId).OnDelete(DeleteBehavior.NoAction);
            //FK_GroupToLesson
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Lessons)
                .WithOne(l => l.Groups)
                .HasForeignKey(l => l.GroupId);
            ////FK_TeacherToLesson
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Lessons)
                .WithOne(l => l.Teachers)
                .HasForeignKey(l => l.TeacherId);
            //FK_TeacherTosLessons
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Lessons)
                .WithOne(l => l.Subjects)
                .HasForeignKey(l => l.SubjectId);

            //MANY-TO-MANY
            modelBuilder.Entity<SubjectTeachers>()
              .HasKey(st => new { st.SubjectId, st.TeacherId });
            //FK_SubjectsTeacher_TO_Subjects
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.SubjectTeachers)
                .WithOne(st => st.Subject)
                .HasForeignKey(st => st.SubjectId);
            //FK_SubjectsTeacher_TO_Teachers
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.SubjectTeachers)
                .WithOne(st => st.Teacher)
                .HasForeignKey(st => st.TeacherId);

            modelBuilder.Entity<GroupSubjects>()
                .HasKey(gs => new { gs.GroupId, gs.SubjectId });
            //FK_GroupSubjects_TO_Groups
            modelBuilder.Entity<Group>()
                .HasMany(g => g.GroupSubjects)
                .WithOne(gs => gs.Group)
                .HasForeignKey(gs => gs.GroupId);
            //FK_GroupSubjects_TO_Subjects
            modelBuilder.Entity<Subject>()
                  .HasMany(s => s.SubjectTeachers)
                  .WithOne(gs => gs.Subject)
                  .HasForeignKey(gs => gs.SubjectId);
        }
    }
}
