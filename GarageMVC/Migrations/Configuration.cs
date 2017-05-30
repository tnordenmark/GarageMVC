namespace GarageMVC.Migrations
{
    using GarageMVC.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageMVC.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageMVC.DataAccess.GarageContext context)
        {
            context.Vehicles.AddOrUpdate(
                new Vehicle
                {
                    Owner = "Gudrun Rut",
                    RegNumber = "AAA321",
                    ParkingPlace = 1,
                    ParkingPrice = 1,
                    Type = VehicleType.Car
                },
                new Vehicle
                {
                    Owner = "Kalle Anka",
                    RegNumber = "ABC311",
                    ParkingPlace = 2,
                    ParkingPrice = 2.5M,
                    Type = VehicleType.Bus
                },
                new Vehicle
                {
                    Owner = "Drudrik von Money",
                    RegNumber = "EBA031",
                    ParkingPlace = 3,
                    ParkingPrice = 0.5M,
                    Type = VehicleType.Mc
                },
                new Vehicle
                {
                    Owner = "Albert Einstein",
                    RegNumber = "ETA452",
                    ParkingPlace = 4,
                    ParkingPrice = 3.5M,
                    Type = VehicleType.Truck
                }
            );
        }
    }
}
