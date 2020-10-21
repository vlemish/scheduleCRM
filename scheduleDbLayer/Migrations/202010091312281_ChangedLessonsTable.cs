namespace scheduleDbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLessonsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "SubjectId");
            AddForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Lessons", new[] { "SubjectId" });
            DropColumn("dbo.Lessons", "SubjectId");
        }
    }
}
