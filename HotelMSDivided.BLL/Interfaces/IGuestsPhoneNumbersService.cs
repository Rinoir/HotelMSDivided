using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IGuestsPhoneNumbersService
    {
        void Create(GuestsPhoneNumbersDTO guestPhone);
        void Delete(int id);
        void Dispose();
    }
}
