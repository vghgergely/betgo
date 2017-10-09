namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitors", "ImageLink", c => c.String());
            AddColumn("dbo.Events", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ImageLink");
            DropColumn("dbo.Competitors", "ImageLink");
        }
    }
}
