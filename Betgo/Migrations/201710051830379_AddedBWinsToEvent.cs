namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBWinsToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "BWinsReturn", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "BWinsReturn");
        }
    }
}
