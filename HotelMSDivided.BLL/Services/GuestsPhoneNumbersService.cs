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

namespace HotelMSDivided.BLL.Services
{
    public class GuestsPhoneNumbersService : IGuestsPhoneNumbersService
    {
        IUnitOfWork db;

        public GuestsPhoneNumbersService(IUnitOfWork context)
        {
            db = context;
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
    }
}
