namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prosumer_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prosumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        TokenBalance = c.Int(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            AddColumn("dbo.ExpectedDatas", "Prosumer_Id", c => c.Int());
            AddColumn("dbo.SmartMeterDatas", "Prosumer_Id", c => c.Int());
            CreateIndex("dbo.ExpectedDatas", "Prosumer_Id");
            CreateIndex("dbo.SmartMeterDatas", "Prosumer_Id");
            AddForeignKey("dbo.ExpectedDatas", "Prosumer_Id", "dbo.Prosumers", "Id");
            AddForeignKey("dbo.SmartMeterDatas", "Prosumer_Id", "dbo.Prosumers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartMeterDatas", "Prosumer_Id", "dbo.Prosumers");
            DropForeignKey("dbo.ExpectedDatas", "Prosumer_Id", "dbo.Prosumers");
            DropForeignKey("dbo.Prosumers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.SmartMeterDatas", new[] { "Prosumer_Id" });
            DropIndex("dbo.Prosumers", new[] { "Address_Id" });
            DropIndex("dbo.ExpectedDatas", new[] { "Prosumer_Id" });
            DropColumn("dbo.SmartMeterDatas", "Prosumer_Id");
            DropColumn("dbo.ExpectedDatas", "Prosumer_Id");
            DropTable("dbo.Prosumers");
        }
    }
}
