using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageMVC.Models
{
    public class Vehicle
    {

        #region Properties
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { set; get; }
        [Required]
        [StringLength(6)]
        public string RegNumber { set; get; }
        public VehicleType Type { set; get; }
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

        /*
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
         */
        #endregion
   
        #region Overrides
        //public override string ToString()
        //{
        //    return string.Format("{0,-10}{1,-10}{2,-10}", GetObjectType(), RegNumber, ParkingDate);
        //}
        #endregion
    }

    public enum VehicleType
    {
        Car,
        Mc,
        Bus,
        Truck
    }
}