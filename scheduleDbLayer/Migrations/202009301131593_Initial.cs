namespace scheduleDbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonTime = c.DateTime(nullable: false),
                        EvenOrOdd = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.GroupId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        FacultyId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.FacultyId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoldayDate = c.DateTime(nullable: false),
                        HolidayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.TeacherId })
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.GroupSubjects",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.SubjectId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.GroupSubjects", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessons", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.GroupSubjects", new[] { "SubjectId" });
            DropIndex("dbo.GroupSubjects", new[] { "GroupId" });
            DropIndex("dbo.SubjectTeachers", new[] { "TeacherId" });
            DropIndex("dbo.SubjectTeachers", new[] { "SubjectId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "FacultyId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "FacultyId" });
            DropTable("dbo.GroupSubjects");
            DropTable("dbo.SubjectTeachers");
            DropTable("dbo.Holidays");
            DropTable("dbo.Students");
            DropTable("dbo.Subjects");
            DropTable("dbo.Teachers");
            DropTable("dbo.Lessons");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
        }
    }
}
