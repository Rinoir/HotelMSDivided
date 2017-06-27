using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.DAL.Entities;

namespace HotelMSDivided.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<EmployeesPositions, int> EmployeesPositions { get; }
        IRepository<GuestPassports, int> GuestPassports { get; }
        IRepository<GuestsPhoneNumbers, int> GuestsPhoneNumbers { get; }
        IRepository<HotelGuests, string> HotelGuests { get; }
        IRepository<HotelRooms, int> HotelRooms { get; }
        IRepository<HotelsRoomRegistration, int> HotelsRoomRegistration { get; }
        IRepository<HotelStaff, string> HotelStaff { get; }
        IRepository<OrdersRegistration, int> OrdersRegistration { get; }
        IRepository<OrderStatuses, int> OrderStatuses { get; }
        IRepository<PaymentMethods, int> PaymentMethods { get; }
        IRepository<PhoneNumbersTypes, int> PhoneNumbersTypes { get; }
        IRepository<RoomClasses, int> RoomClasses { get; }
        IRepository<StaffsPassports, int> StaffsPassports { get; }
        IRepository<StaffsPhoneNumbers, int> StaffsPhoneNumbers { get; }
        void Save();
    }
}
