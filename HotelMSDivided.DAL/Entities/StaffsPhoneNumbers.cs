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
    
    public partial class StaffsPhoneNumbers
    {
        public int Id { get; set; }
        public string StaffMail { get; set; }
        public int PhoneNumberTypeCode { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual HotelStaff HotelStaff { get; set; }
        public virtual PhoneNumbersTypes PhoneNumbersTypes { get; set; }
    }
}
