using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.DAL.Entities;
using HotelMSDivided.DAL.Interfaces;

namespace HotelMSDivided.DAL.Repositories
{
    public class StaffsPassportsRepository : IRepository<StaffsPassports, int>
    {
        private HotelDataBaseEntities db;

        public StaffsPassportsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(StaffsPassports item)
        {
            db.StaffsPassports.Add(item);
        }

        public void Delete(int id)
        {
            StaffsPassports room = db.StaffsPassports.Find(id);
            if (room != null)
            {
                db.StaffsPassports.Remove(room);
            }
        }

        public IEnumerable<StaffsPassports> Find(Func<StaffsPassports, bool> predicate)
        {
            return db.StaffsPassports.Where(predicate).ToList();
        }

        public void Update(StaffsPassports item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public StaffsPassports Get(int id)
        {
            return db.StaffsPassports.Find(id);
        }

        public IEnumerable<StaffsPassports> GetAll()
        {
            return db.StaffsPassports.ToList();
        }
    }
}
