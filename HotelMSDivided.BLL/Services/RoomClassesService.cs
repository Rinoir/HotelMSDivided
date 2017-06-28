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
    public class RoomClassesService : IRoomClassesService
    {
        IUnitOfWork db;

        public RoomClassesService(IUnitOfWork context)
        {
            db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public RoomClassesDTO GetRoomClass(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Room class id is null", "");
            }
            var roomClass = db.RoomClasses.Get(id.Value);
            var roomClassDTO = new RoomClassesDTO()
            {
                RoomClassCode = roomClass.RoomClassCode,
                RoomClassName = roomClass.RoomClassName
            };

            return roomClassDTO;
        }

        public IEnumerable<RoomClassesDTO> GetRoomClasses()
        {
            var roomClasses = db.RoomClasses.GetAll();
            var roomClassesDTO = new List<RoomClassesDTO>();
            foreach (var item in roomClasses)
            {
                roomClassesDTO.Add(new RoomClassesDTO()
                {
                    RoomClassCode = item.RoomClassCode,
                    RoomClassName = item.RoomClassName
                });
            }
            return roomClassesDTO;
        }
    }
}
