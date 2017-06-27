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
    public class GuestsPhoneNumbersRepository : IRepository<GuestsPhoneNumbers, int>
    {
        private HotelDataBaseEntities db;

        public GuestsPhoneNumbersRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(GuestsPhoneNumbers item)
        {
            db.GuestsPhoneNumbers.Add(item);
        }

        public void Delete(int id)
        {
            GuestsPhoneNumbers guestPhone = db.GuestsPhoneNumbers.Find(id);
            if (guestPhone != null)
            {
                db.GuestsPhoneNumbers.Remove(guestPhone);
            }
        }

        public IEnumerable<GuestsPhoneNumbers> Find(Func<GuestsPhoneNumbers, bool> predicate)
        {
            return db.GuestsPhoneNumbers.Where(predicate).ToList();
        }

        public void Update(GuestsPhoneNumbers item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public GuestsPhoneNumbers Get(int id)
        {
            return db.GuestsPhoneNumbers.Find(id);
        }

        public IEnumerable<GuestsPhoneNumbers> GetAll()
        {
            return db.GuestsPhoneNumbers.ToList();
        }
    }
}
