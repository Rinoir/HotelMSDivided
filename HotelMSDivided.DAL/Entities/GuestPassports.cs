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
    
    public partial class GuestPassports
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        public string PassportSerialNumber { get; set; }
        public int PassportNumber { get; set; }
    
        public virtual HotelGuests HotelGuests { get; set; }
    }
}