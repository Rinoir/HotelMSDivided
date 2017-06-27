//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelMSDivided.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersRegistration
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        public int RoomNumber { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public System.DateTime LeavingDate { get; set; }
        public int PaymentMethodCode { get; set; }
        public int OrderStatus { get; set; }
    
        public virtual HotelGuests HotelGuests { get; set; }
        public virtual HotelRooms HotelRooms { get; set; }
        public virtual OrderStatuses OrderStatuses { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
    }
}
