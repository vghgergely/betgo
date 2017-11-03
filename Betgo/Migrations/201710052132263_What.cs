namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class What : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "Better_Id" });
            AddColumn("dbo.Bets", "BetterId", c => c.String(nullable: false));
            DropColumn("dbo.Bets", "Better_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bets", "Better_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Bets", "BetterId");
            CreateIndex("dbo.Bets", "Better_Id");
            AddForeignKey("dbo.Bets", "Better_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
