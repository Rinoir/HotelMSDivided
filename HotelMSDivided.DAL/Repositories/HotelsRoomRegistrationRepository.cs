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
    public class HotelsRoomRegistrationRepository : IRepository<HotelsRoomRegistration, int>
    {
        private HotelDataBaseEntities db;

        public HotelsRoomRegistrationRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(HotelsRoomRegistration item)
        {
            db.HotelsRoomRegistration.Add(item);
        }

        public void Delete(int id)
        {
            HotelsRoomRegistration registration = db.HotelsRoomRegistration.Find(id);
            if (registration != null)
            {
                db.HotelsRoomRegistration.Remove(registration);
            }
        }

        public IEnumerable<HotelsRoomRegistration> Find(Func<HotelsRoomRegistration, bool> predicate)
        {
            return db.HotelsRoomRegistration.Where(predicate).ToList();
        }

        public void Update(HotelsRoomRegistration item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public HotelsRoomRegistration Get(int id)
        {
            return db.HotelsRoomRegistration.Find(id);
        }

        public IEnumerable<HotelsRoomRegistration> GetAll()
        {
            return db.HotelsRoomRegistration.ToList();
        }
    }
}
