using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;
using HotelMSDivided.BLL.Infrastructure;
using HotelMSDivided.BLL.Interfaces;
using HotelMSDivided.DAL.Entities;
using HotelMSDivided.DAL.Interfaces;
using AutoMapper;

namespace HotelMSDivided.BLL.Services
{
    class OrderStatusesService : IOrderStatusesService
    {
        IUnitOfWork db;

        public OrderStatusesService(IUnitOfWork context)
        {
            db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public string GetOrderStatus(int? id)
        {
            var method = from item in db.OrderStatuses.GetAll()
                         where item.Id == id
                         select item;
            return method.First().StatusName;
        }

        public int GetOrderStatusId(string name)
        {
            var method = from item in db.OrderStatuses.GetAll()
                         where item.StatusName == name
                         select item;
            return method.First().Id;
        }
    }
}
