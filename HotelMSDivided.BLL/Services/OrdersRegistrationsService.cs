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
                PaymentMethodCode = GetPaymentMethodCode(order.PaymentMethod),
                OrderStatus = GetStatusCode(order.OrderStatus)
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
            });

            var order = Mapper.Map<OrdersRegistration, OrdersRegistrationDTO>(orders.First());
            order.PaymentMethod = GetPaymentMethodName(orders.First().PaymentMethodCode);
            order.OrderStatus = GetStatusName(orders.First().OrderStatus);
            return order;
        }

        public OrdersRegistrationDTO GetOrder(int id)
        {
            var order = db.OrdersRegistration.Get(id);
            if (order == null)
            {
                return null;
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
            });

            var orderDTO = Mapper.Map<OrdersRegistration, OrdersRegistrationDTO>(order);
            orderDTO.PaymentMethod = GetPaymentMethodName(order.PaymentMethodCode);
            orderDTO.OrderStatus = GetStatusName(order.OrderStatus);
            return orderDTO;
        }

        public IEnumerable<OrdersRegistrationDTO> GetOrders()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
            });
            var orders = db.OrdersRegistration.GetAll() as List<OrdersRegistration>;
            var ordersDTO = Mapper.Map<IEnumerable<OrdersRegistration>, List<OrdersRegistrationDTO>>(orders);
            for (int i = 0; i < ordersDTO.Count(); i++)
            {
                ordersDTO[i].PaymentMethod = GetPaymentMethodName(orders[i].PaymentMethodCode);
                ordersDTO[i].OrderStatus = GetStatusName(orders[i].OrderStatus);
            }

            return ordersDTO;
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
                PaymentMethodCode = GetPaymentMethodCode(order.PaymentMethod),
                OrderStatus = GetStatusCode(order.OrderStatus)
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

        public int GetPaymentMethodCode(string name)
        {
            var methodService = new PaymentMethodsService(new ContextUnitOfWork());
            return methodService.GetPaymentMethodId(name);
        }

        public string GetPaymentMethodName(int? id)
        {
            var methodService = new PaymentMethodsService(new ContextUnitOfWork());
            return methodService.GetPaymentMethod(id.Value);
        }

        public int GetStatusCode(string name)
        {
            var statusService = new OrderStatusesService(new ContextUnitOfWork());
            return statusService.GetOrderStatusId(name);
        }

        public string GetStatusName(int? id)
        {
            var statusService = new OrderStatusesService(new ContextUnitOfWork());
            return statusService.GetOrderStatus(id.Value);
        }

        public void MoveToRegistration(HotelsRoomRegistrationDTO registration)
        {
            var reg = new HotelsRoomRegistration()
            {
                GuestMail = registration.GuestMail,
                StaffMail = registration.StaffMail,
                BookedRoomNumber = registration.BookedRoomNumber,
                BookingDate = registration.BookingDate,
                ArrivalDate = registration.ArrivalDate,
                PaymentMethodCode = GetPaymentMethodCode(registration.PaymentMethod),
                OrderStatus = GetStatusCode(registration.OrderStatus)
            };

            db.HotelsRoomRegistration.Create(reg);
            db.Save();
        }
    }
}
