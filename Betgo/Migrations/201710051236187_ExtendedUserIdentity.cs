namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendedUserIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "EmailAddress", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Money", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Money");
            DropColumn("dbo.AspNetUsers", "EmailAddress");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
