namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SadBoye : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors");
            DropForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors");
            DropIndex("dbo.Events", new[] { "CompetitorA_Id" });
            DropIndex("dbo.Events", new[] { "CompetitorB_Id" });
            AlterColumn("dbo.Events", "CompetitorA_Id", c => c.Int());
            AlterColumn("dbo.Events", "CompetitorB_Id", c => c.Int());
            CreateIndex("dbo.Events", "CompetitorA_Id");
            CreateIndex("dbo.Events", "CompetitorB_Id");
            AddForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors", "Id");
            AddForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors");
            DropForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors");
            DropIndex("dbo.Events", new[] { "CompetitorB_Id" });
            DropIndex("dbo.Events", new[] { "CompetitorA_Id" });
            AlterColumn("dbo.Events", "CompetitorB_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "CompetitorA_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CompetitorB_Id");
            CreateIndex("dbo.Events", "CompetitorA_Id");
            AddForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors", "Id", cascadeDelete: true);
        }
    }
}
