using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using scheduleDbLayer.Models;
using scheduleDbLayer.Models.DbModels;

namespace scheduleDbLayer.EF
{
    public class ScheduleEntities : DbContext
    {

        public ScheduleEntities()
            : base("Local")
        {

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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ONE-TO-MANY
            //FK_GroupToStudent
            modelBuilder.Entity<Student>()
                .HasRequired<Group>(s => s.Groups)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.GroupId).WillCascadeOnDelete(false);
            //FK_FacultyToStudent
            modelBuilder.Entity<Student>()
                .HasRequired<Faculty>(s => s.Faculties)
                .WithMany(f => f.Students)
                .HasForeignKey<int>(s => s.FacultyId).WillCascadeOnDelete(false) ;
            //FK_FacultyToGroup
            modelBuilder.Entity<Group>()
                .HasRequired<Faculty>(g => g.Faculties)
                .WithMany(f => f.Groups)
                .HasForeignKey<int>(g => g.FacultyId).WillCascadeOnDelete(false);
            //FK_GroupToLesson
            modelBuilder.Entity<Lesson>()
                .HasRequired<Group>(l => l.Groups)
                .WithMany(g => g.Lessons)
                .HasForeignKey(l => l.GroupId).WillCascadeOnDelete(false);
            ////FK_TeacherToLesson
            modelBuilder.Entity<Lesson>()
                .HasRequired<Teacher>(l => l.Teachers)
                .WithMany(t => t.Lessons)
                .HasForeignKey(l => l.TeacherId).WillCascadeOnDelete(false);
            //FK_TeacherTosLessons
            modelBuilder.Entity<Lesson>()
                .HasRequired<Subject>(l => l.Subjects)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SubjectId).WillCascadeOnDelete(false);

            //MANY-TO-MANY
            //SubjectsTeachers
            //modelBuilder.Entity<Subject>()
            //    .HasMany(s => s.Teachers)
            //    .WithMany(t => t.Subjects)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("SubjectId");
            //        cs.MapRightKey("TeacherId");
            //        cs.ToTable("SubjectTeachers");
            //    });

            modelBuilder.Entity<SubjectTeachers>()
                .HasKey(st => new { st.SubjectId, st.TeacherId });

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.SubjectTeachers)
                .WithRequired()
                .HasForeignKey(s => s.SubjectId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.SubjectTeachers)
                .WithRequired()
                .HasForeignKey(t => t.TeacherId);

            //GroupsSubjects
            //modelBuilder.Entity<Group>()
            //    .HasMany(g => g.Subjects)
            //    .WithMany(s => s.Groups)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("GroupId");
            //        cs.MapRightKey("SubjectId");
            //        cs.ToTable("GroupSubjects");
            //    });

            modelBuilder.Entity<GroupSubjects>()
                .HasKey(gs => new { gs.GroupId, gs.SubjectId });

            modelBuilder.Entity<Group>()
                .HasMany(g => g.GroupSubjects)
                .WithRequired()
                .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.GroupSubjects)
                .WithRequired()
                .HasForeignKey(s => s.SubjectId);

        }
    }
}
