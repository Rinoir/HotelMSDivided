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
using AutoMapper;

namespace HotelMSDivided.BLL.Services
{
    public class HotelRoomsService : IHotelRoomsService
    {
        IUnitOfWork db;

        public HotelRoomsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Create(HotelRoomsDTO room)
        {
            db.HotelRooms.Create(new HotelRooms
            {
                RoomClassCode = room.RoomClassCode,
                Floor = room.Floor,
                DayCost = room.DayCost,
                RoomsAmount = room.RoomsAmount
            });
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public HotelRoomsDTO GetHotelRoom(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Room number is null", "");
            }

            var room = db.HotelRooms.Get(id.Value);

            if (room == null)
            {
                throw new ValidationException("No room with such number", "");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<HotelRooms, HotelRoomsDTO>());
            return Mapper.Map<HotelRooms, HotelRoomsDTO>(room);
        }

        public IEnumerable<HotelRoomsDTO> GetHotelRooms()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<HotelRooms, HotelRoomsDTO>());
            return Mapper.Map<IEnumerable<HotelRooms>, List<HotelRoomsDTO>>(db.HotelRooms.GetAll());
        }

        public void Update(HotelRoomsDTO room)
        {
            db.HotelRooms.Update(new HotelRooms
            {
                RoomNumber = room.RoomNumber,
                RoomClassCode = room.RoomClassCode,
                Floor = room.Floor,
                DayCost = room.DayCost,
                RoomsAmount = room.RoomsAmount
            });

            db.Save();
        }
    }
}
