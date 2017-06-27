using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class StaffsPassportsViewModel
    {
        public int Id { get; set; }
        public string StaffMail { get; set; }
        public string PassportSerialNumber { get; set; }
        public int PassportNumber { get; set; }

        public virtual HotelStaffViewModel HotelStaff { get; set; }
    }
}