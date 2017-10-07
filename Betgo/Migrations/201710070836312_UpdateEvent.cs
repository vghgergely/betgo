namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "PaidOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "Winner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Winner");
            DropColumn("dbo.Events", "PaidOut");
        }
    }
}
