﻿using System;
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
    class PaymentMethodsService : IPaymentMethodsService
    {
        IUnitOfWork db;

        public PaymentMethodsService(IUnitOfWork context)
        {
            db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public string GetPaymentMethod(int? id)
        {
            var method = from item in db.PaymentMethods.GetAll()
                         where item.PaymentMethodCode == id
                         select item;
            return method.First().PaymentMethodName;
        }

        public int GetPaymentMethodId(string name)
        {
            var method = from item in db.PaymentMethods.GetAll()
                         where item.PaymentMethodName == name
                         select item;
            return method.First().PaymentMethodCode;
        }

        public IEnumerable<PaymentMethodsDTO> GetPaymentMethods()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>().ReverseMap());
            return Mapper.Map<IEnumerable<PaymentMethods>, List<PaymentMethodsDTO>>(db.PaymentMethods.GetAll());
        }
    }
}
