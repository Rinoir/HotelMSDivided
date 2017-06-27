using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class GuestPassportsViewModel
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        [Display(Name = "Passport Serial Number")]
        [StringLength(2, MinimumLength = 2)]
        public string PassportSerialNumber { get; set; }
        [Display(Name = "Passport Number")]
        public int PassportNumber { get; set; }

        public virtual HotelGuestsViewModel HotelGuests { get; set; }
    }
}