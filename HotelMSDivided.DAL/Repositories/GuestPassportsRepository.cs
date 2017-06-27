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
    public class GuestPassportsRepository : IRepository<GuestPassports, int>
    {
        private HotelDataBaseEntities db;

        public GuestPassportsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(GuestPassports item)
        {
            db.GuestPassports.Add(item);
        }

        public void Delete(int id)
        {
            GuestPassports guestPasspoert = db.GuestPassports.Find(id);
            if (guestPasspoert != null)
            {
                db.GuestPassports.Remove(guestPasspoert);
            }
        }

        public IEnumerable<GuestPassports> Find(Func<GuestPassports, bool> predicate)
        {
            return db.GuestPassports.Where(predicate).ToList();
        }

        public void Update(GuestPassports item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public GuestPassports Get(int id)
        {
            return db.GuestPassports.Find(id);
        }

        public IEnumerable<GuestPassports> GetAll()
        {
            return db.GuestPassports.ToList();
        }
    }
}