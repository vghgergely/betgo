namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDetailsToBody : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Body", c => c.String());
            DropColumn("dbo.Events", "Details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Details", c => c.String());
            DropColumn("dbo.Events", "Body");
        }
    }
}
