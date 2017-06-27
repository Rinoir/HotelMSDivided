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
    public class PaymentMethodsRepository : IRepository<PaymentMethods, int>
    {
        private HotelDataBaseEntities db;

        public PaymentMethodsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(PaymentMethods item)
        {
            db.PaymentMethods.Add(item);
        }

        public void Delete(int id)
        {
            PaymentMethods room = db.PaymentMethods.Find(id);
            if (room != null)
            {
                db.PaymentMethods.Remove(room);
            }
        }

        public IEnumerable<PaymentMethods> Find(Func<PaymentMethods, bool> predicate)
        {
            return db.PaymentMethods.Where(predicate).ToList();
        }

        public void Update(PaymentMethods item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public PaymentMethods Get(int id)
        {
            return db.PaymentMethods.Find(id);
        }

        public IEnumerable<PaymentMethods> GetAll()
        {
            return db.PaymentMethods.ToList();
        }
    }
}
