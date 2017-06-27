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
    public class HotelRoomsRepository : IRepository<HotelRooms, int>
    {
        private HotelDataBaseEntities db;

        public HotelRoomsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(HotelRooms item)
        {
            db.HotelRooms.Add(item);
        }

        public void Delete(int id)
        {
            HotelRooms room = db.HotelRooms.Find(id);
            if (room != null)
            {
                db.HotelRooms.Remove(room);
            }
        }

        public IEnumerable<HotelRooms> Find(Func<HotelRooms, bool> predicate)
        {
            return db.HotelRooms.Where(predicate).ToList();
        }

        public void Update(HotelRooms item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public HotelRooms Get(int id)
        {
            return db.HotelRooms.Find(id);
        }

        public IEnumerable<HotelRooms> GetAll()
        {
            return db.HotelRooms.ToList();
        }
    }
}
