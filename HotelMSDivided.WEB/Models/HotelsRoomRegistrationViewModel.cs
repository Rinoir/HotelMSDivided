using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class HotelsRoomRegistrationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Guest login")]
        public string GuestMail { get; set; }
        [Display(Name = "Employee login")]
        public string StaffMail { get; set; }
        [Display(Name = "Room number")]
        public int BookedRoomNumber { get; set; }
        [Display(Name = "Booking date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime BookingDate { get; set; }
        [Display(Name = "Arrival date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ArrivalDate { get; set; }
        [Display(Name = "Leaving date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime LeavingDate { get; set; }
        [Display(Name = "Actual leaving date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ActualLeavingDate { get; set; }
        public int PaymentMethodCode { get; set; }
        public int OrderStatus { get; set; }

        public virtual HotelGuestsViewModel HotelGuests { get; set; }
        public virtual HotelRoomsViewModel HotelRooms { get; set; }
        public virtual OrderStatusesViewModel OrderStatuses { get; set; }
        public virtual PaymentMethodsViewModel PaymentMethods { get; set; }
        public virtual HotelStaffViewModel HotelStaff { get; set; }
    }
}