namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailsToEventsAndCompetitors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitors", "Details", c => c.String());
            AddColumn("dbo.Events", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Details");
            DropColumn("dbo.Competitors", "Details");
        }
    }
}
