namespace scheduleDbLayer.Migrations
{
    using scheduleDbLayer.Models;
    using scheduleDbLayer.Models.DbModels;
    using scheduleDbLayer.Repos;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<scheduleDbLayer.EF.ScheduleEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(scheduleDbLayer.EF.ScheduleEntities context)
        {

            ////TEACHERS
            //List<Teacher> teachers = new List<Teacher>()
            //{
            //    new Teacher("Філь Н.Ю."), //1
            //    new Teacher("Кононихін О.С."),//2
            //    new Teacher("Петренко Ю.А."), //3
            //    new Teacher("Нефьодов Л.І."),//4
            //    new Teacher("Біньковска А.Б."),//5
            //    new Teacher("Поляков Є.О.")//6
            //};

            //var teachersRepo = new TeacherRepo();
            //teachersRepo.AddRange(teachers);
            //teachers.ForEach(x => context.Teachers.AddOrUpdate(
            //    t => new { t.TeacherName }, x));

            ////Faculties
            //BaseRepo<Faculty> _repoFaculty = new BaseRepo<Faculty>();

            //_repoFaculty.AddRange(new List<Faculty>()
            //{
            //    new Faculty() { FacultyName = "Mechanical" },
            //    new Faculty() { FacultyName = "Automobile" }
            //});

            //context.Faculties.AddOrUpdate(x => new { x.FacultyName });

            ////Groups
            //BaseRepo<Group> _repoGroups = new BaseRepo<Group>();
            //_repoGroups.Add(new Group() { GroupName = "MA51-20", FacultyId = 1 });
            //context.Groups.AddOrUpdate(x => new { x.GroupName });

            ////Subjects
            //var subjectsRepo = new SubjectRepo();

            //List<Subject> subjects = new List<Subject>()
            //{
            //    new Subject("Автоматизація наукових досліджень") , //1
            //    new Subject("Автоматизовані банки даних АСУТП"),//2
            //    new Subject("Системи керування зі штучним інтелектом"),//3
            //    new Subject("Сенсорні мережі АСУТП"),//4
            //    new Subject("Комп'ютерне управління технологічними процесами"), //5
            //    new Subject("САПР в АСУ"),//6
            //    new Subject("Кваліфікаційна робота"),//7
            //    new Subject("Управління проектами корпоративних комп'ютерних систем"),//8
            //    new Subject("Технологічні вимірювання та прилади")//9

            //};

            //subjectsRepo.AddRange(subjects);

            //var _subjectTeachersRepo = new SubjectTeachersRepo();

            //var subjectTeachers = new List<SubjectTeachers>()
            //{
            //    new SubjectTeachers(1,1),
            //    new SubjectTeachers(1,2),
            //    new SubjectTeachers(2,4),
            //    new SubjectTeachers(3,5),
            //    new SubjectTeachers(4,6),
            //    new SubjectTeachers(4,7),
            //    new SubjectTeachers(4,8),
            //    new SubjectTeachers(5,3),
            //    new SubjectTeachers(6,9)
            //};
            //_subjectTeachersRepo.AddRange(subjectTeachers);


            //var _groupsSubjectsRepo = new GroupSubjectsRepo();
            //var groupSubjects = new List<GroupSubjects>()
            //{
            //    new GroupSubjects(1,1),
            //    new GroupSubjects(1,2),
            //    new GroupSubjects(1,3),
            //    new GroupSubjects(1,4),
            //    new GroupSubjects(1,5),
            //    new GroupSubjects(1,6),
            //    new GroupSubjects(1,7),
            //    new GroupSubjects(1,8),
            //    new GroupSubjects(1,9),
            //};

            //_groupsSubjectsRepo.AddRange(groupSubjects);


            //var lessons = new List<Lesson>()
            //{
            //    //MONDAY
            //    //EVEN
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),2,1,1,2,DayOfWeek.Monday, LessonType.Lecture),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),2,1,5,3,DayOfWeek.Monday, LessonType.Lecture),
            //    new Lesson(TimeSpan.Parse(LessonTime.FourthLesson.Value),2,1,2,4,DayOfWeek.Monday, LessonType.Practice),

            //    //ODD
            //    new Lesson(TimeSpan.Parse(LessonTime.FirstLesson.Value),1,1,1,1,DayOfWeek.Monday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),1,1,1,1,DayOfWeek.Monday, LessonType.Lecture),

            //    //Tuesday
            //    //EVEN
            //    new Lesson(TimeSpan.Parse(LessonTime.FirstLesson.Value),2,1,1,2,DayOfWeek.Tuesday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),2,1,2,4,DayOfWeek.Tuesday, LessonType.Lecture),
               
            //    //ODD
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),1,1,3,5,DayOfWeek.Tuesday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),1,1,3,5,DayOfWeek.Tuesday, LessonType.Lecture),

            //    //Wednesday
            //    //EVEN
            //    new Lesson(TimeSpan.Parse(LessonTime.FirstLesson.Value),2,1,4,6,DayOfWeek.Wednesday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),2,1,4,7,DayOfWeek.Wednesday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),2,1,4,8,DayOfWeek.Wednesday, LessonType.Lecture),

            //    //ODD
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),1,1,4,7,DayOfWeek.Wednesday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),1,1,4,6,DayOfWeek.Wednesday, LessonType.Lecture),

            //    //TUESDAY
            //    //ODD
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),1,1,6,9,DayOfWeek.Thursday, LessonType.Lecture),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),1,1,5,3,DayOfWeek.Thursday, LessonType.Practice),
                
            //    //EVEN
            //    new Lesson(TimeSpan.Parse(LessonTime.SecondLesson.Value),2,1,6,9,DayOfWeek.Thursday, LessonType.Practice),
            //    new Lesson(TimeSpan.Parse(LessonTime.ThirdLesson.Value),2,1,5,3,DayOfWeek.Thursday, LessonType.Practice),
            //};

            //var lessonsRepo = new LessonRepo();

            //lessonsRepo.AddRange(lessons);
        }
    }
}
