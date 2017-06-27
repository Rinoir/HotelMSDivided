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
    public class PhoneNumbersTypesRepository : IRepository<PhoneNumbersTypes, int>
    {
        private HotelDataBaseEntities db;

        public PhoneNumbersTypesRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(PhoneNumbersTypes item)
        {
            db.PhoneNumbersTypes.Add(item);
        }

        public void Delete(int id)
        {
            PhoneNumbersTypes room = db.PhoneNumbersTypes.Find(id);
            if (room != null)
            {
                db.PhoneNumbersTypes.Remove(room);
            }
        }

        public IEnumerable<PhoneNumbersTypes> Find(Func<PhoneNumbersTypes, bool> predicate)
        {
            return db.PhoneNumbersTypes.Where(predicate).ToList();
        }

        public void Update(PhoneNumbersTypes item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public PhoneNumbersTypes Get(int id)
        {
            return db.PhoneNumbersTypes.Find(id);
        }

        public IEnumerable<PhoneNumbersTypes> GetAll()
        {
            return db.PhoneNumbersTypes.ToList();
        }
    }
}
