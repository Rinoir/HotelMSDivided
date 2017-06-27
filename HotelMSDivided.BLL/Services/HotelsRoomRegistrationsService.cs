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
    public class HotelsRoomRegistrationsService : IHotelsRoomRegistrationsService
    {
        IUnitOfWork db;

        public HotelsRoomRegistrationsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Create(HotelsRoomRegistrationDTO registration)
        {
            db.HotelsRoomRegistration.Create(new HotelsRoomRegistration
            {
                GuestMail = registration.GuestMail,
                StaffMail = registration.StaffMail,
                BookedRoomNumber = registration.BookedRoomNumber,
                BookingDate = registration.BookingDate,
                ArrivalDate = registration.ArrivalDate,
                LeavingDate = registration.LeavingDate,
                PaymentMethodCode = registration.PaymentMethodCode,
                OrderStatus = registration.OrderStatus
            });
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public HotelsRoomRegistrationDTO GetRegistration(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Id is null", "");
            }

            var registration = db.HotelsRoomRegistration.Get(id.Value);

            if (registration == null)
            {
                throw new ValidationException("Wrong registration id", "");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<HotelsRoomRegistration, HotelsRoomRegistrationDTO>());
            return Mapper.Map<HotelsRoomRegistration, HotelsRoomRegistrationDTO>(registration);
        }

        public IEnumerable<HotelsRoomRegistrationDTO> GetRegistrations()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<HotelsRoomRegistration, HotelsRoomRegistrationDTO>());
            return Mapper.Map<IEnumerable<HotelsRoomRegistration>, List<HotelsRoomRegistrationDTO>>(db.HotelsRoomRegistration.GetAll());
        }

        public void Update(HotelsRoomRegistrationDTO registration)
        {
            db.HotelsRoomRegistration.Update(new HotelsRoomRegistration
            {
                Id = registration.Id,
                GuestMail = registration.GuestMail,
                StaffMail = registration.StaffMail,
                BookedRoomNumber = registration.BookedRoomNumber,
                BookingDate = registration.BookingDate,
                ArrivalDate = registration.ArrivalDate,
                LeavingDate = registration.LeavingDate,
                ActualLeavingDate = registration.ActualLeavingDate,
                PaymentMethodCode = registration.PaymentMethodCode,
                OrderStatus = registration.OrderStatus
            });
            db.Save();
        }
    }
}
