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
    public class StaffsPhoneNumbersRepository : IRepository<StaffsPhoneNumbers, int>
    {
        private HotelDataBaseEntities db;

        public StaffsPhoneNumbersRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(StaffsPhoneNumbers item)
        {
            db.StaffsPhoneNumbers.Add(item);
        }

        public void Delete(int id)
        {
            StaffsPhoneNumbers room = db.StaffsPhoneNumbers.Find(id);
            if (room != null)
            {
                db.StaffsPhoneNumbers.Remove(room);
            }
        }

        public IEnumerable<StaffsPhoneNumbers> Find(Func<StaffsPhoneNumbers, bool> predicate)
        {
            return db.StaffsPhoneNumbers.Where(predicate).ToList();
        }

        public void Update(StaffsPhoneNumbers item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public StaffsPhoneNumbers Get(int id)
        {
            return db.StaffsPhoneNumbers.Find(id);
        }

        public IEnumerable<StaffsPhoneNumbers> GetAll()
        {
            return db.StaffsPhoneNumbers.ToList();
        }
    }
}
