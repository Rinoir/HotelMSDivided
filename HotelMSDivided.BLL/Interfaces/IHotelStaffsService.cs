using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IHotelStaffsService
    {
        HotelStaffDTO GetHotelEmployee(string login);
        bool IsExists(string login);
        void Dispose();
    }
}
