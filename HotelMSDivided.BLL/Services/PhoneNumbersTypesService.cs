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
    class PhoneNumbersTypesService : IPhoneNumbersTypesService
    {
        IUnitOfWork db;

        public PhoneNumbersTypesService(IUnitOfWork context)
        {
            db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PhoneNumbersTypesDTO> GetNumbersTypes()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap());
            return Mapper.Map<IEnumerable<PhoneNumbersTypes>, List<PhoneNumbersTypesDTO>>(db.PhoneNumbersTypes.GetAll());

        }

        public PhoneNumbersTypesDTO GetNumberType(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Id is null", "");
            }
            var type = db.PhoneNumbersTypes.Get(id.Value);
            if (type != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<PhoneNumbersTypes, PhoneNumbersTypesDTO>().ReverseMap());
                return Mapper.Map<PhoneNumbersTypes, PhoneNumbersTypesDTO>(type);
            }
            throw new ValidationException("No phone type with such id", "");
        }
    }
}
