using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class StaffsPhoneNumbersViewModel
    {
        public int Id { get; set; }
        public string StaffMail { get; set; }
        public int PhoneNumberTypeCode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual HotelStaffViewModel HotelStaff { get; set; }
        public virtual PhoneNumbersTypesViewModel PhoneNumbersTypes { get; set; }
    }
}