namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EmailAddress", c => c.String(nullable: false));
        }
    }
}
