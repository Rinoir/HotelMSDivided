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

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StaffsPassports, StaffsPassportsDTO>().ReverseMap();
                cfg.CreateMap<StaffsPhoneNumbers, StaffsPhoneNumbersDTO>().ReverseMap();
                cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap();
                cfg.CreateMap<HotelsRoomRegistration, HotelsRoomRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrdersRegistration, OrdersRegistrationDTO>().ReverseMap();
                cfg.CreateMap<OrderStatuses, OrderStatusesDTO>().ReverseMap();
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap();
                cfg.CreateMap<EmployeesPositions, EmployeesPositionsDTO>().ReverseMap();
            });

            var employeeDTO = new HotelStaffDTO()
            {
                StaffMail = employee.StaffMail,
                Surname = employee.Surname,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                PositionCode = employee.PositionCode,
                Salary = employee.Salary,
                Schedule = employee.Schedule,
                EmployeesPositions = Mapper.Map<EmployeesPositions, EmployeesPositionsDTO>(employee.EmployeesPositions),
                HotelsRoomRegistration = Mapper.Map<ICollection<HotelsRoomRegistration>, ICollection<HotelsRoomRegistrationDTO>>(employee.HotelsRoomRegistration),
                StaffsPassport = Mapper.Map<StaffsPassports, StaffsPassportsDTO>(employee.StaffsPassports.First()),
                StaffsPhoneNumbers = Mapper.Map<ICollection<StaffsPhoneNumbers>, ICollection<StaffsPhoneNumbersDTO>>(employee.StaffsPhoneNumbers)
            };
            return employeeDTO;
        }

        public bool IsExists(string login)
        {
            return (db.HotelStaff.Get(login) != null);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
