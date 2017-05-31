namespace GarageMVC.Migrations
{
    using GarageMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageMVC.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GarageMVC.DataAccess.GarageContext context)
        {
            context.Vehicles.AddOrUpdate(
                new Vehicle
                {
                    Owner = "Gudrun Rut",
                    RegNumber = "AAA321",
                    ParkingPrice = 1,
                    ParkingPlace = 1,
                    Type = VehicleType.Car
                },
                new Vehicle
                {
                    Owner = "Kalle Anka",
                    RegNumber = "ABC311",
                    ParkingPrice = 2,
                    ParkingPlace = 2,
                    Type = VehicleType.Bus
                },
                new Vehicle
                {
                    Owner = "Drudrik von Money",
                    RegNumber = "EBA031",
                    ParkingPrice = 0.45M,
                    ParkingPlace = 3,
                    Type = VehicleType.Mc
                },
                new Vehicle
                {
                    Owner = "Albert Einstine",
                    RegNumber = "FBI132",
                    ParkingPrice = 3.5M,
                    ParkingPlace = 4,
                    Type = VehicleType.Truck
                }
            );
        }
    }
}
