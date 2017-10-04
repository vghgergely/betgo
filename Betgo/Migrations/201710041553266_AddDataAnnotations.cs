namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "Better_Id" });
            AlterColumn("dbo.Bets", "Better_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "CompetitorA", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "CompetitorB", c => c.String(nullable: false));
            CreateIndex("dbo.Bets", "Better_Id");
            AddForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "Better_Id" });
            AlterColumn("dbo.Events", "CompetitorB", c => c.String());
            AlterColumn("dbo.Events", "CompetitorA", c => c.String());
            AlterColumn("dbo.Bets", "Better_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bets", "Better_Id");
            AddForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
