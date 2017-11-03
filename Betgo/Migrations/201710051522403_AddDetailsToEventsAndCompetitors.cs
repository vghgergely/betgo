namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailsToEventsAndCompetitors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitors", "Body", c => c.String());
            AddColumn("dbo.Events", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Body");
            DropColumn("dbo.Competitors", "Body");
        }
    }
}
