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
using HotelMSDivided.DAL.Repositories;
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

        public OrdersRegistrationDTO GetOrder(string login)
        {
            var orders = from item in db.OrdersRegistration.GetAll()
                         where item.GuestMail == login &&
                         item.OrderStatus == 1
                         select item;
            if (orders.Count() == 0)
            {
                return null;
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
            });

            return Mapper.Map<OrdersRegistration, OrdersRegistrationDTO>(orders.First());
        }

        public IEnumerable<OrdersRegistrationDTO> GetOrders()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
            });
            return Mapper.Map<IEnumerable<OrdersRegistration>, List<OrdersRegistrationDTO>>(db.OrdersRegistration.GetAll());
        }

        public bool IsExists(string login)
        {
            return (Enumerable.Any(from item in db.OrdersRegistration.GetAll()
                                   where item.GuestMail == login
                                   select item));
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

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PaymentMethodsDTO> GetPaymentMethods()
        {
            var methodsService = new PaymentMethodsService(new ContextUnitOfWork());
            return methodsService.GetPaymentMethods();
        }
    }
}
