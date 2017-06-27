using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IHotelRoomsService
    {
        HotelRoomsDTO GetHotelRoom(int? id);
        IEnumerable<HotelRoomsDTO> GetHotelRooms();
        void Create(HotelRoomsDTO room);
        void Update(HotelRoomsDTO room);
        void Dispose();
    }
}
