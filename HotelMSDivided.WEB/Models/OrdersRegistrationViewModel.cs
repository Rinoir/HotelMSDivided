using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class OrdersRegistrationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Guest login")]
        public string GuestMail { get; set; }
        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Booking date")]
        public System.DateTime BookingDate { get; set; }
        [Display(Name = "Arrival date")]
        public System.DateTime ArrivalDate { get; set; }
        [Display(Name = "Leaving date")]
        public System.DateTime LeavingDate { get; set; }
        public int PaymentMethodCode { get; set; }
        public int OrderStatus { get; set; }

        public virtual HotelGuestsViewModel HotelGuests { get; set; }
        public virtual HotelRoomsViewModel HotelRooms { get; set; }
        public virtual OrderStatusesViewModel OrderStatuses { get; set; }
        public virtual PaymentMethodsViewModel PaymentMethods { get; set; }
    }
}