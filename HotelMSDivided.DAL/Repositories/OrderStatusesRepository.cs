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
    public class OrderStatusesRepository : IRepository<OrderStatuses, int>
    {
        private HotelDataBaseEntities db;

        public OrderStatusesRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(OrderStatuses item)
        {
            db.OrderStatuses.Add(item);
        }

        public void Delete(int id)
        {
            OrderStatuses room = db.OrderStatuses.Find(id);
            if (room != null)
            {
                db.OrderStatuses.Remove(room);
            }
        }

        public IEnumerable<OrderStatuses> Find(Func<OrderStatuses, bool> predicate)
        {
            return db.OrderStatuses.Where(predicate).ToList();
        }

        public void Update(OrderStatuses item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public OrderStatuses Get(int id)
        {
            return db.OrderStatuses.Find(id);
        }

        public IEnumerable<OrderStatuses> GetAll()
        {
            return db.OrderStatuses.ToList();
        }
    }
}
