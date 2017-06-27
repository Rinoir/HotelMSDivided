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
    public class RoomClassesRepository : IRepository<RoomClasses, int>
    {
        private HotelDataBaseEntities db;

        public RoomClassesRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(RoomClasses item)
        {
            db.RoomClasses.Add(item);
        }

        public void Delete(int id)
        {
            RoomClasses room = db.RoomClasses.Find(id);
            if (room != null)
            {
                db.RoomClasses.Remove(room);
            }
        }

        public IEnumerable<RoomClasses> Find(Func<RoomClasses, bool> predicate)
        {
            return db.RoomClasses.Where(predicate).ToList();
        }

        public void Update(RoomClasses item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public RoomClasses Get(int id)
        {
            return db.RoomClasses.Find(id);
        }

        public IEnumerable<RoomClasses> GetAll()
        {
            return db.RoomClasses.ToList();
        }
    }
}
