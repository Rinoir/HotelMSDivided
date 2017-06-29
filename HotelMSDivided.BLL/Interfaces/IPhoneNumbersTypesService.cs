using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    interface IPhoneNumbersTypesService
    {
        IEnumerable<PhoneNumbersTypesDTO> GetNumbersTypes();
        PhoneNumbersTypesDTO GetNumberType(int? id);
        void Dispose();
    }
}
