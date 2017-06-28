using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class HotelsRoomRegistrationDTO
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        public string StaffMail { get; set; }
        public int BookedRoomNumber { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public System.DateTime LeavingDate { get; set; }
        public Nullable<System.DateTime> ActualLeavingDate { get; set; }
        public int PaymentMethodCode { get; set; }
        public int OrderStatus { get; set; }

        //public virtual HotelGuestsDTO HotelGuests { get; set; }
        //public virtual HotelRoomsDTO HotelRooms { get; set; }
        public virtual OrderStatusesDTO OrderStatuses { get; set; }
        public virtual PaymentMethodsDTO PaymentMethods { get; set; }
        //public virtual HotelStaffDTO HotelStaff { get; set; }
    }
}
