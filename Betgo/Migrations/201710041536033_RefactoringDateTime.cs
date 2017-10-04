namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ActualDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Date", c => c.String());
            AlterColumn("dbo.Events", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "ActualDateTime");
        }
    }
}
