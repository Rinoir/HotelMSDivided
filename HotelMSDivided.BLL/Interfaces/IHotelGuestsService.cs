using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IHotelGuestsService
    {
        IEnumerable<HotelGuestsDTO> GetHotelGuests();
        HotelGuestsDTO GetHotelGuest(string login);
        IEnumerable<PhoneNumbersTypesDTO> GetNumbersTypes();
        void Create(GuestModel guest);
        bool IsExists(string login);
        void Dispose();
    }
}
