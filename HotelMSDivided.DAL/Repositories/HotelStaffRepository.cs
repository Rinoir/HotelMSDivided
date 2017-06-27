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
    public class HotelStaffRepository : IRepository<HotelStaff, string>
    {
        private HotelDataBaseEntities db;

        public HotelStaffRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(HotelStaff item)
        {
            db.HotelStaff.Add(item);
        }

        public void Delete(string id)
        {
            HotelStaff guest = db.HotelStaff.Find(id);
            if (guest != null)
            {
                db.HotelStaff.Remove(guest);
            }
        }

        public IEnumerable<HotelStaff> Find(Func<HotelStaff, bool> predicate)
        {
            return db.HotelStaff.Where(predicate).ToList();
        }

        public void Update(HotelStaff item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public HotelStaff Get(string id)
        {
            return db.HotelStaff.Find(id);
        }

        public IEnumerable<HotelStaff> GetAll()
        {
            return db.HotelStaff.ToList();
        }
    }
}
