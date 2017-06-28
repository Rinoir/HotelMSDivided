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
    public class HotelGuestsService : IHotelGuestsService
    {
        IUnitOfWork db;

        public HotelGuestsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Create(GuestModel guest)
        {
            var hotelGuests = new HotelGuests()
            {
                GuestMail = guest.GuestMail,
                Surname = guest.Surname,
                Name = guest.Name,
                Patronymic = guest.Patronymic
            };

            var guestPassports = new GuestPassports()
            {
                GuestMail = guest.GuestMail,
                PassportSerialNumber = guest.PassportSerialNumber,
                PassportNumber = guest.PassportNumber
            };

            var guestPhoneNumbers = new GuestsPhoneNumbers()
            {
                GuestMail = guest.GuestMail,
                PhoneNumberTypeCode = guest.PhoneNumberTypeCode,
                PhoneNumber = guest.PhoneNumber
            };

            hotelGuests.GuestPassports.Add(guestPassports);
            hotelGuests.GuestsPhoneNumbers.Add(guestPhoneNumbers);

            db.HotelGuests.Create(hotelGuests);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public HotelGuestsDTO GetHotelGuest(string login)
        {
            if (login == null)
            {
                throw new ValidationException("Login is null", "");
            }

            var guest = db.HotelGuests.Get(login);

            if (guest == null)
            {
                throw new ValidationException("Wrong login", "");
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GuestPassports, GuestPassportsDTO>().ReverseMap();
                cfg.CreateMap<GuestsPhoneNumbers, GuestsPhoneNumbersDTO>().ReverseMap();
                cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap();
                cfg.CreateMap<HotelsRoomRegistration, HotelsRoomRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
            });

            var guestDTO = new HotelGuestsDTO()
            {
                GuestMail = guest.GuestMail,
                Surname = guest.Surname,
                Name = guest.Name,
                Patronymic = guest.Patronymic,
                GuestPassport = Mapper.Map<GuestPassports, GuestPassportsDTO>(guest.GuestPassports.First()),
                GuestsPhoneNumbers = Mapper.Map<ICollection<GuestsPhoneNumbers>, ICollection<GuestsPhoneNumbersDTO>>(guest.GuestsPhoneNumbers),
                HotelsRoomRegistration = Mapper.Map<ICollection<HotelsRoomRegistration>, ICollection<HotelsRoomRegistrationDTO>>(guest.HotelsRoomRegistration),
                OrdersRegistration = Mapper.Map<ICollection<OrdersRegistration>, ICollection<OrdersRegistrationDTO>>(guest.OrdersRegistration)
            };

            return guestDTO;
        }

        public IEnumerable<HotelGuestsDTO> GetHotelGuests()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<GuestPassports, GuestPassportsDTO>().ReverseMap();
                cfg.CreateMap<GuestsPhoneNumbers, GuestsPhoneNumbersDTO>().ReverseMap();
                cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap();
                cfg.CreateMap<HotelsRoomRegistration, HotelsRoomRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
            });
            var guests = db.HotelGuests.GetAll();
            var guestsDTO = new List<HotelGuestsDTO>();

            foreach (var item in guests)
            {
                guestsDTO.Add(new HotelGuestsDTO()
                {
                    GuestMail = item.GuestMail,
                    Surname = item.Surname,
                    Name = item.Name,
                    Patronymic = item.Patronymic,
                    GuestPassport = Mapper.Map<GuestPassports, GuestPassportsDTO>(item.GuestPassports.First()),
                    GuestsPhoneNumbers = Mapper.Map<ICollection<GuestsPhoneNumbers>, ICollection<GuestsPhoneNumbersDTO>>(item.GuestsPhoneNumbers),
                    HotelsRoomRegistration = Mapper.Map<ICollection<HotelsRoomRegistration>, ICollection<HotelsRoomRegistrationDTO>>(item.HotelsRoomRegistration),
                    OrdersRegistration = Mapper.Map<ICollection<OrdersRegistration>, ICollection<OrdersRegistrationDTO>>(item.OrdersRegistration)
                });
            }
            return guestsDTO;
        }
    }
}
