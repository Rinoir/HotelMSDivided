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
    public class EmployeesPositionsRepository : IRepository<EmployeesPositions, int>
    {
        private HotelDataBaseEntities db;

        public EmployeesPositionsRepository(HotelDataBaseEntities context)
        {
            db = context;
        }

        public void Create(EmployeesPositions item)
        {
            db.EmployeesPositions.Add(item);
        }

        public void Delete(int id)
        {
            EmployeesPositions position = db.EmployeesPositions.Find(id);
            if(position != null)
            {
                db.EmployeesPositions.Remove(position);
            }
        }

        public IEnumerable<EmployeesPositions> Find(Func<EmployeesPositions, bool> predicate)
        {
            return db.EmployeesPositions.Where(predicate).ToList();
        }

        public void Update(EmployeesPositions item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public EmployeesPositions Get(int id)
        {
            return db.EmployeesPositions.Find(id);
        }

        public IEnumerable<EmployeesPositions> GetAll()
        {
            return db.EmployeesPositions.ToList();
        }
    }
}
