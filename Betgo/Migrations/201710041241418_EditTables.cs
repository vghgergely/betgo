namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors");
            DropForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors");
            DropIndex("dbo.Events", new[] { "CompetitorA_Id" });
            DropIndex("dbo.Events", new[] { "CompetitorB_Id" });
            AddColumn("dbo.Events", "CompetitorA", c => c.String());
            AddColumn("dbo.Events", "CompetitorB", c => c.String());
            AddColumn("dbo.Events", "oddsA", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "oddsB", c => c.Double(nullable: false));
            DropColumn("dbo.Events", "CompetitorA_Id");
            DropColumn("dbo.Events", "CompetitorB_Id");
            DropTable("dbo.Competitors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Competitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Odds = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "CompetitorB_Id", c => c.Int());
            AddColumn("dbo.Events", "CompetitorA_Id", c => c.Int());
            DropColumn("dbo.Events", "oddsB");
            DropColumn("dbo.Events", "oddsA");
            DropColumn("dbo.Events", "CompetitorB");
            DropColumn("dbo.Events", "CompetitorA");
            CreateIndex("dbo.Events", "CompetitorB_Id");
            CreateIndex("dbo.Events", "CompetitorA_Id");
            AddForeignKey("dbo.Events", "CompetitorB_Id", "dbo.Competitors", "Id");
            AddForeignKey("dbo.Events", "CompetitorA_Id", "dbo.Competitors", "Id");
        }
    }
}
