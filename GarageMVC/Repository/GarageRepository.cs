using GarageMVC.DataAccess;

namespace GarageMVC.Repository
{
    public class GarageRepository
    {
        private GarageContext db;

        public GarageRepository()
        {
            db = new GarageContext();
        }
    }
}