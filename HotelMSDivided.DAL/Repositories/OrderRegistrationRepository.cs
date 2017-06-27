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
    public class OrderRegistrationRepository : IRepository<OrdersRegistration, int>
    {
        private HotelDataBaseEntities db;

        public OrderRegistrationRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(OrdersRegistration item)
        {
            db.OrdersRegistration.Add(item);
        }

        public void Delete(int id)
        {
            OrdersRegistration room = db.OrdersRegistration.Find(id);
            if (room != null)
            {
                db.OrdersRegistration.Remove(room);
            }
        }

        public IEnumerable<OrdersRegistration> Find(Func<OrdersRegistration, bool> predicate)
        {
            return db.OrdersRegistration.Where(predicate).ToList();
        }

        public void Update(OrdersRegistration item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public OrdersRegistration Get(int id)
        {
            return db.OrdersRegistration.Find(id);
        }

        public IEnumerable<OrdersRegistration> GetAll()
        {
            return db.OrdersRegistration.ToList();
        }
    }
}
