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

            Mapper.Initialize(cfg => cfg.CreateMap<HotelGuests, HotelGuestsDTO>());
            return Mapper.Map<HotelGuests, HotelGuestsDTO>(guest);
        }

        public IEnumerable<HotelGuestsDTO> GetHotelGuests()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<HotelGuests, HotelGuestsDTO>());
            return Mapper.Map<IEnumerable<HotelGuests>, List<HotelGuestsDTO>>(db.HotelGuests.GetAll());
        }
    }
}
