namespace TraderInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProducedEnergy = c.Int(nullable: false),
                        ConsumedEnergy = c.Int(nullable: false),
                        SumOfEnergy = c.Int(nullable: false),
                        ProsumerId = c.Int(nullable: false),
                        TransferWindow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransferWindows", t => t.TransferWindow_Id, cascadeDelete: true)
                .Index(t => t.TransferWindow_Id);
            
            CreateTable(
                "dbo.TransferWindows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Period = c.Int(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Price = c.Int(nullable: false),
                        SmartGridId = c.Int(nullable: false),
                        SumOfTrades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trades", "TransferWindow_Id", "dbo.TransferWindows");
            DropIndex("dbo.Trades", new[] { "TransferWindow_Id" });
            DropTable("dbo.TransferWindows");
            DropTable("dbo.Trades");
        }
    }
}
