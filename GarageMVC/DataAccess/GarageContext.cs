using System.Data.Entity;

namespace GarageMVC.DataAccess
{
    public class GarageContext : DbContext
    {
            public DbSet<Models.Vehicle> Vehicles { get; set; }
            public GarageContext() : base("DefaultConnection") { }
    }
}