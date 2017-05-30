using GarageMVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace GarageMVC.Repository
{
    public class GarageRepository
    {
        private GarageContext db;

        public GarageRepository()
        {
            db = new GarageContext();
        }

        //Add a vehicle to database
        public void Add(Models.Vehicle vehicle)
        {
            if (vehicle != null)
            {
                vehicle.ParkingPlace = db.Vehicles.Count();

                if (vehicle.Type == Models.VehicleType.Car) { vehicle.ParkingPrice = 1; }
                else if (vehicle.Type == Models.VehicleType.Mc) { vehicle.ParkingPrice = 0.45M; }
                else if (vehicle.Type == Models.VehicleType.Truck) { vehicle.ParkingPrice = 3.5M; }
                else if (vehicle.Type == Models.VehicleType.Bus) { vehicle.ParkingPrice = 2.5M; }
               
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
            }
        }
        //GET all vehicles from database
        public List<Models.Vehicle> GetAll()
        {
            return db.Vehicles.ToList();
        }
        //GET specific vehicle from database
        public Models.Vehicle GetVehicle(string regNr)
        {
            return db.Vehicles.Where(v => v.RegNumber == regNr).FirstOrDefault();
        }
        public Models.Vehicle GetVehicle(int pPlace)
        {
            return db.Vehicles.Where(v => v.ParkingPlace == pPlace).FirstOrDefault();
        }
        //Edit a vehicle
        public void Edit(Models.Vehicle vehicle)
        {
            //Edits the element without removing and inserting it
            db.Entry(vehicle).State = EntityState.Modified; 
            //Saves the new Data in the Database
            db.SaveChanges();
        }
        //Remove vehicle from database and return vehicle information
        public Models.Vehicle Delete(int pPlace)
        {
            Models.Vehicle vehicle;
            vehicle = db.Vehicles.Where(v => v.ParkingPlace == pPlace).FirstOrDefault();
            if (vehicle != null)
            {
                TimeSpan tspan = DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (tspan.Minutes);

                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
            return vehicle;
        }
        public Models.Vehicle Delete(string regNr)
        {
            Models.Vehicle vehicle;
            vehicle = db.Vehicles.Where(v => v.RegNumber == regNr).FirstOrDefault();
            if (vehicle != null)
            {
                TimeSpan tspan = DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (tspan.Minutes);

                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
            return vehicle;
        }
    }
}