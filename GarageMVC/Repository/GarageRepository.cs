using GarageMVC.DataAccess;
using GarageMVC.Models;
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
        #region Get Vehicle(s)
        //GET all vehicles from database
        public List<Vehicle> GetAll()
        {
            return db.Vehicles.ToList();
        }
        public Models.Vehicle GetVehicle(string regNr)
        {
            return db.Vehicles.Where(v => v.RegNumber == regNr).FirstOrDefault();
        }
        public Models.Vehicle GetVehicle(int id)
        {
            return db.Vehicles.Where(v => v.ID == id).FirstOrDefault();
        }
        //GET filtered vehicle list
        public List<Vehicle> GetFilteredList(VehicleType type)
        {
            return db.Vehicles.Where(vehicle => vehicle.Type == type).ToList();
        }
        #endregion
        //Edit a vehicle
        public void Edit(Models.Vehicle vehicle)
        {
            //Edits the element without removing and inserting it
            db.Entry(vehicle).State = EntityState.Modified; 
            //Saves the new Data in the Database
            db.SaveChanges();
        }
        //Remove vehicle from database and return vehicle information
        public Models.Vehicle Remove(int id)
        {
            Models.Vehicle vehicle;
            vehicle = db.Vehicles.Where(v => v.ID == id).FirstOrDefault();
            if (vehicle != null)
            {
                System.TimeSpan tspan = System.DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (tspan.Minutes);

                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
            return vehicle;
        }
        public Models.Vehicle Remove(string regNr)
        {
            Models.Vehicle vehicle;
            vehicle = db.Vehicles.Where(v => v.RegNumber == regNr).FirstOrDefault();
            if (vehicle != null)
            {
                System.TimeSpan tspan = System.DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (tspan.Minutes);

                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
            return vehicle;
        }
        //Search vehicle(s)
        public List<Models.Vehicle> Search(string searchTerm)
        {
            int pSlot = -1;

            //Try to parse the input string to double, if it works, the user want to search for price
            try
            {
                pSlot = int.Parse(searchTerm);
            }
            catch //If the parse didin't work it might be a name, category or article number so return a list containing either of those
            {
                return db.Vehicles.Where(vehicle => vehicle.Owner.Contains(searchTerm) || vehicle.RegNumber == searchTerm).ToList();
            }
            return db.Vehicles.Where(vehicle => vehicle.ParkingPlace == pSlot).ToList();
        }
   }
}