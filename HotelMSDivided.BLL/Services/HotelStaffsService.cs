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
    public class HotelStaffsService : IHotelStaffsService
    {
        IUnitOfWork db;

        public HotelStaffsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public HotelStaffDTO GetHotelEmployee(string login)
        {
            if (login == null)
            {
                throw new ValidationException("Login is null", "");
            }

            var employee = db.HotelStaff.Get(login);

            if (employee == null)
            {
                throw new ValidationException("Wrong login", "");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<HotelStaff, HotelStaffDTO>());
            return Mapper.Map<HotelStaff, HotelStaffDTO>(employee);
        }
    }
}
