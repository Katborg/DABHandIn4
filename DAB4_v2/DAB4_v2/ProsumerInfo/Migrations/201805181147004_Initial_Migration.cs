namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpectedDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Consumption = c.Int(nullable: false),
                        Production = c.Int(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmartMeterDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Produced = c.Int(nullable: false),
                        Consumed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SmartMeterDatas");
            DropTable("dbo.ExpectedDatas");
            DropTable("dbo.Addresses");
        }
    }
}
