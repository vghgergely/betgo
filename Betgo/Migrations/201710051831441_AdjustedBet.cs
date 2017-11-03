namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedBet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "ChosenOption", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bets", "ChosenOption");
        }
    }
}
