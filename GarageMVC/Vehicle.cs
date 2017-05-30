using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSystem
{
    class Vehicle
    {

        #region Properties
        public string RegNumber { set; get; }
        public decimal ParkingPrice { set; get; }
        public DateTime ParkingDate { set; get; }
        #endregion

        #region Constructor
        public Vehicle()
        {
            ParkingDate = DateTime.Now;
        }
        #endregion

        #region Methods
        //public string GetObjectType()
        //{
        //    return this.GetType().ToString().Remove(0, 13);
        //}

        public bool Equals(Vehicle other)
        {
            if(other == null) return false;
            if(this.RegNumber == other.RegNumber) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;

            Vehicle vehicleObject = obj as Vehicle;
            if(vehicleObject == null) return false;
            else return Equals(vehicleObject);
        }
        public override int GetHashCode()
        {
            return this.RegNumber.GetHashCode();
        }
        #endregion

        #region Overrides
        //public override string ToString()
        //{
        //    return string.Format("{0,-10}{1,-10}{2,-10}", GetObjectType(), RegNumber, ParkingDate);
        //}
        #endregion
    }

    public enum Type
    {
        car,
        mc,
        bus,
        truck
    }
}