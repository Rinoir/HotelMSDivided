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
using HotelMSDivided.DAL.Repositories;
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

            var classService = new RoomClassesService(new ContextUnitOfWork());
            var roomDTO = new HotelRoomsDTO()
            {
                RoomNumber = room.RoomNumber,
                RoomClassCode = room.RoomClassCode,
                Floor = room.Floor,
                DayCost = room.DayCost,
                RoomsAmount = room.RoomsAmount,
                RoomClasses = classService.GetRoomClass(room.RoomClassCode)
            };
            return roomDTO;
        }

        public IEnumerable<HotelRoomsDTO> GetHotelRooms()
        {
            var hotelRooms = db.HotelRooms.GetAll();
            var hotelRoomsDTO = new List<HotelRoomsDTO>();
            var classService = new RoomClassesService(new ContextUnitOfWork());
            foreach (var item in hotelRooms)
            {
                hotelRoomsDTO.Add(new HotelRoomsDTO()
                {
                    RoomNumber = item.RoomNumber,
                    RoomClassCode = item.RoomClassCode,
                    Floor = item.Floor,
                    DayCost = item.DayCost,
                    RoomsAmount = item.RoomsAmount,
                    RoomClasses = classService.GetRoomClass(item.RoomClassCode)
                });
            }
            
            return hotelRoomsDTO;
        }

        public IEnumerable<RoomClassesDTO> GetRoomClasses()
        {
            var classService = new RoomClassesService(new ContextUnitOfWork());
            return classService.GetRoomClasses();
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
