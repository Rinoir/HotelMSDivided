using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.DAL.Entities;
using HotelMSDivided.DAL.Interfaces;

namespace HotelMSDivided.DAL.Repositories
{
    public class ContextUnitOfWork : IUnitOfWork
    {
        private HotelDataBaseEntities db;

        private EmployeesPositionsRepository employeesPositionsRepository;
        private GuestPassportsRepository guestPassportsRepository;
        private GuestsPhoneNumbersRepository guestsPhoneNumbersRepository;
        private HotelGuestsRepository hotelGuestsRepository;
        private HotelRoomsRepository hotelRoomsRepository;
        private HotelsRoomRegistrationRepository hotelsRoomRegistrationRepository;
        private HotelStaffRepository hotelStaffRepository;
        private OrderRegistrationRepository orderRegistrationRepository;
        private OrderStatusesRepository orderStatusesRepository;
        private PaymentMethodsRepository paymentMethodsRepository;
        private PhoneNumbersTypesRepository phoneNumbersTypesRepository;
        private RoomClassesRepository roomClassesRepository;
        private StaffsPassportsRepository staffsPassportsRepository;
        private StaffsPhoneNumbersRepository staffsPhoneNumbersRepository;

        public ContextUnitOfWork()
        {
            db = new HotelDataBaseEntities();
        }

        public IRepository<EmployeesPositions, int> EmployeesPositions
        {
            get
            {
                if (employeesPositionsRepository == null)
                {
                    employeesPositionsRepository = new EmployeesPositionsRepository(db);
                }
                return employeesPositionsRepository;
            }
        }

        public IRepository<GuestPassports, int> GuestPassports
        {
            get
            {
                if (guestPassportsRepository == null)
                {
                    guestPassportsRepository = new GuestPassportsRepository(db);
                }
                return guestPassportsRepository;
            }
        }

        public IRepository<GuestsPhoneNumbers, int> GuestsPhoneNumbers
        {
            get
            {
                if (guestsPhoneNumbersRepository == null)
                {
                    guestsPhoneNumbersRepository = new GuestsPhoneNumbersRepository(db);
                }
                return guestsPhoneNumbersRepository;
            }
        }

        public IRepository<HotelGuests, string> HotelGuests
        {
            get
            {
                if (hotelGuestsRepository == null)
                {
                    hotelGuestsRepository = new HotelGuestsRepository(db);
                }
                return hotelGuestsRepository;
            }
        }

        public IRepository<HotelRooms, int> HotelRooms
        {
            get
            {
                if(hotelRoomsRepository == null)
                {
                    hotelRoomsRepository = new HotelRoomsRepository(db);
                }
                return hotelRoomsRepository;
            }
        }

        public IRepository<HotelsRoomRegistration, int> HotelsRoomRegistration
        {
            get
            {
                if (hotelsRoomRegistrationRepository == null)
                {
                    hotelsRoomRegistrationRepository = new HotelsRoomRegistrationRepository(db);
                }
                return hotelsRoomRegistrationRepository;
            }
        }

        public IRepository<HotelStaff, string> HotelStaff
        {
            get
            {
                if (hotelStaffRepository == null)
                {
                    hotelStaffRepository = new HotelStaffRepository(db);
                }
                return hotelStaffRepository;
            }
        }

        public IRepository<OrdersRegistration, int> OrdersRegistration
        {
            get
            {
                if (orderRegistrationRepository == null)
                {
                    orderRegistrationRepository = new OrderRegistrationRepository(db);
                }
                return orderRegistrationRepository;
            }
        }

        public IRepository<OrderStatuses, int> OrderStatuses
        {
            get
            {
                if (orderStatusesRepository == null)
                {
                    orderStatusesRepository = new OrderStatusesRepository(db);
                }
                return orderStatusesRepository;
            }
        }

        public IRepository<PaymentMethods, int> PaymentMethods
        {
            get
            {
                if (paymentMethodsRepository == null)
                {
                    paymentMethodsRepository = new PaymentMethodsRepository(db);
                }
                return paymentMethodsRepository;
            }
        }

        public IRepository<PhoneNumbersTypes, int> PhoneNumbersTypes
        {
            get
            {
                if (phoneNumbersTypesRepository == null)
                {
                    phoneNumbersTypesRepository = new PhoneNumbersTypesRepository(db);
                }
                return phoneNumbersTypesRepository;
            }
        }

        public IRepository<RoomClasses, int> RoomClasses
        {
            get
            {
                if (roomClassesRepository == null)
                {
                    roomClassesRepository = new RoomClassesRepository(db);
                }
                return roomClassesRepository;
            }
        }

        public IRepository<StaffsPassports, int> StaffsPassports
        {
            get
            {
                if (staffsPassportsRepository == null)
                {
                    staffsPassportsRepository = new StaffsPassportsRepository(db);
                }
                return staffsPassportsRepository;
            }
        }

        public IRepository<StaffsPhoneNumbers, int> StaffsPhoneNumbers
        {
            get
            {
                if (staffsPhoneNumbersRepository == null)
                {
                    staffsPhoneNumbersRepository = new StaffsPhoneNumbersRepository(db);
                }
                return staffsPhoneNumbersRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
