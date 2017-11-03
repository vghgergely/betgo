namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CompetitorA_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "CompetitorB_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CompetitorA_Id");
            CreateIndex("dbo.Events", "CompetitorB_Id");
            AddForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors", "Id", cascadeDelete: false);
            DropColumn("dbo.Events", "CompetitorA");
            DropColumn("dbo.Events", "CompetitorB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "CompetitorB", c => c.String(nullable: false));
            AddColumn("dbo.Events", "CompetitorA", c => c.String(nullable: false));
            DropForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors");
            DropForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors");
            DropIndex("dbo.Events", new[] { "CompetitorB_Id" });
            DropIndex("dbo.Events", new[] { "CompetitorA_Id" });
            DropColumn("dbo.Events", "CompetitorB_Id");
            DropColumn("dbo.Events", "CompetitorA_Id");
        }
    }
}
