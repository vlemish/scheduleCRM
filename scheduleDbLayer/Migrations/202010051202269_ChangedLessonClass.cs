namespace scheduleDbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLessonClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "DayOfWeek", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "LessonTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "LessonTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lessons", "DayOfWeek");
        }
    }
}
