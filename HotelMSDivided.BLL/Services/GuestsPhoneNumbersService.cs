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
    public class GuestsPhoneNumbersService : IGuestsPhoneNumbersService
    {
        IUnitOfWork db;

        public GuestsPhoneNumbersService(IUnitOfWork context)
        {
            db = context;
        }

        public GuestsPhoneNumbersDTO GetPhoneNumber(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Id is null", "");
            }

            var phone = db.GuestsPhoneNumbers.Get(id.Value);

            if (phone == null)
            {
                throw new ValidationException("No phone number with such id", "");
            }
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GuestsPhoneNumbers, GuestsPhoneNumbersDTO>().ReverseMap();
                cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap();
            });

            return Mapper.Map<GuestsPhoneNumbers, GuestsPhoneNumbersDTO>(phone);
        }

        public void Create(GuestsPhoneNumbersDTO guestPhone)
        {
            db.GuestsPhoneNumbers.Create(new GuestsPhoneNumbers
            {
                GuestMail = guestPhone.GuestMail,
                PhoneNumberTypeCode = guestPhone.PhoneNumberTypeCode,
                PhoneNumber = guestPhone.PhoneNumber
            });
            db.Save();
        }

        public void Delete(int id)
        {
            db.GuestsPhoneNumbers.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PhoneNumbersTypesDTO> GetNumbersTypes()
        {
            var numberService = new PhoneNumbersTypesService(new ContextUnitOfWork());
            return numberService.GetNumbersTypes();
        }
    }
}
