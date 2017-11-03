namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "Long", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Long");
            DropColumn("dbo.Events", "Lat");
        }
    }
}
