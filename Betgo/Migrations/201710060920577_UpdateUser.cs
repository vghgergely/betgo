namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.Bets", "BetterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bets", "BetterId", c => c.String(nullable: false));
            DropColumn("dbo.Bets", "UserId");
        }
    }
}
