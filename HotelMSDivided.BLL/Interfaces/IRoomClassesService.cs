﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IRoomClassesService
    {
        IEnumerable<RoomClassesDTO> GetRoomClasses();
        RoomClassesDTO GetRoomClass(int? id);
        void Dispose();
    }
}
