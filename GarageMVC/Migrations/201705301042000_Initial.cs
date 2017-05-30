namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false, maxLength: 6),
                        Owner = c.String(),
                        Type = c.Int(nullable: false),
                        ParkingPlace = c.Int(nullable: false),
                        ParkingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParkingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
