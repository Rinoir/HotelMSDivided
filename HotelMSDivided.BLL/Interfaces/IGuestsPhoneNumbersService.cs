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
        GuestsPhoneNumbersDTO GetPhoneNumber(int? id);
        void Create(GuestsPhoneNumbersDTO guestPhone);
        IEnumerable<PhoneNumbersTypesDTO> GetNumbersTypes();
        void Delete(int id);
        void Dispose();
    }
}
