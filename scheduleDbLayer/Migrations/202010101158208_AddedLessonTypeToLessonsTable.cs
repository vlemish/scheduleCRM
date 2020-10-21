namespace scheduleDbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLessonTypeToLessonsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "LessonType", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "LessonType");
        }
    }
}
