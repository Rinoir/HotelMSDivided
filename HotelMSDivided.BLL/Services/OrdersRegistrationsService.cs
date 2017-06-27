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
    public class OrdersRegistrationsService : IOrdersRegistrationsService
    {
        IUnitOfWork db;

        public OrdersRegistrationsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Create(OrdersRegistrationDTO order)
        {
            db.OrdersRegistration.Create(new OrdersRegistration
            {
                GuestMail = order.GuestMail,
                RoomNumber = order.RoomNumber,
                BookingDate = order.BookingDate,
                ArrivalDate = order.ArrivalDate,
                LeavingDate = order.LeavingDate,
                PaymentMethodCode = order.PaymentMethodCode,
                OrderStatus = order.OrderStatus
            });
            db.Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Id is null", "");
            }

            db.OrdersRegistration.Delete(id.Value);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<OrdersRegistrationDTO> GetOrders()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>());
            return Mapper.Map<IEnumerable<OrdersRegistration>, List<OrdersRegistrationDTO>>(db.OrdersRegistration.GetAll());
        }

        public void Update(OrdersRegistrationDTO order)
        {
            db.OrdersRegistration.Update(new OrdersRegistration
            {
                Id = order.Id,
                GuestMail = order.GuestMail,
                RoomNumber = order.RoomNumber,
                BookingDate = order.BookingDate,
                ArrivalDate = order.ArrivalDate,
                LeavingDate = order.LeavingDate,
                PaymentMethodCode = order.PaymentMethodCode,
                OrderStatus = order.OrderStatus
            });
            db.Save();
        }
    }
}
