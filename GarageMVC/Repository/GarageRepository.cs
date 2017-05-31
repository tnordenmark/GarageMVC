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
                int index=1;
                bool checking = true;
                foreach(var v in SortParking(false))
                {
                    if (index!=v.ParkingPlace && checking==true)
                    {
                        vehicle.ParkingPlace = index;
                        checking = false;
                    }

                    index++;
                }
                if(vehicle.ParkingPlace==0)
                {
                    vehicle.ParkingPlace = index;
                }
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
        //GET Sorted Lists
        public List<Vehicle> SortParking(bool descend)
        {
            if(descend)
            {
                return db.Vehicles.OrderByDescending(v => v.ParkingPlace).ToList();
            }
            return db.Vehicles.OrderBy(v=>v.ParkingPlace).ToList();
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
        //Updates the parking prices for each vehicle
        public void UpdateParkPrice()
        {
            foreach(var vehicle in db.Vehicles)
            {
                //reset the parkingPrice to it's default values
                if (vehicle.Type == VehicleType.Car) { vehicle.ParkingPrice = 1; }
                else if (vehicle.Type == VehicleType.Mc) { vehicle.ParkingPrice = 0.45M; }
                else if (vehicle.Type == VehicleType.Bus) { vehicle.ParkingPrice = 2; }
                else { vehicle.ParkingPrice = 3.50M; }
                //Calculate the timespan and than update the cost
                System.TimeSpan tspan = System.DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (System.Convert.ToDecimal(tspan.TotalMinutes));
            }
            db.SaveChanges();
        }
        //Remove vehicle from database and return vehicle information
        public Models.Vehicle Remove(int id)
        {
            Models.Vehicle vehicle;
            vehicle = db.Vehicles.Where(v => v.ID == id).FirstOrDefault();
            if (vehicle != null)
            {
                //reset the parkingPrice to it's default values
                if (vehicle.Type == VehicleType.Car) { vehicle.ParkingPrice = 1; }
                else if (vehicle.Type == VehicleType.Mc) { vehicle.ParkingPrice = 0.45M; }
                else if (vehicle.Type == VehicleType.Bus) { vehicle.ParkingPrice = 2; }
                else { vehicle.ParkingPrice = 3.50M; }
                //Get Current ParkingPrice
                System.TimeSpan tspan = System.DateTime.Now - vehicle.ParkingDate;
                vehicle.ParkingPrice = vehicle.ParkingPrice * (System.Convert.ToDecimal(tspan.TotalMinutes));
                //Remove vehicle from database
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
                //reset the parkingPrice to it's default values
                if (vehicle.Type == VehicleType.Car) { vehicle.ParkingPrice = 1; }
                else if (vehicle.Type == VehicleType.Mc) { vehicle.ParkingPrice = 0.45M; }
                else if (vehicle.Type == VehicleType.Bus) { vehicle.ParkingPrice = 2; }
                else { vehicle.ParkingPrice = 3.50M; }
                //Get Current ParkingPrice
                System.TimeSpan tspan = System.DateTime.Now - vehicle.ParkingDate;

                vehicle.ParkingPrice = vehicle.ParkingPrice * (System.Convert.ToDecimal(tspan.TotalMinutes));
                //Remove vehicle from database
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
            catch
            {
                return db.Vehicles.Where(vehicle => vehicle.Owner.Contains(searchTerm) || vehicle.RegNumber == searchTerm).ToList();
            }
            return db.Vehicles.Where(vehicle => vehicle.ParkingPlace == pSlot).ToList();
        }
   }
}