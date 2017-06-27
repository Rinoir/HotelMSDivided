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
    public class HotelGuestsRepository : IRepository<HotelGuests, string>
    {
        private HotelDataBaseEntities db;

        public HotelGuestsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(HotelGuests item)
        {
            db.HotelGuests.Add(item);
        }

        public void Delete(string id)
        {
            HotelGuests guest = db.HotelGuests.Find(id);
            if (guest != null)
            {
                db.HotelGuests.Remove(guest);
            }
        }

        public IEnumerable<HotelGuests> Find(Func<HotelGuests, bool> predicate)
        {
            return db.HotelGuests.Where(predicate).ToList();
        }

        public void Update(HotelGuests item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public HotelGuests Get(string id)
        {
            return db.HotelGuests.Find(id);
        }

        public IEnumerable<HotelGuests> GetAll()
        {
            return db.HotelGuests.ToList();
        }
    }
}
