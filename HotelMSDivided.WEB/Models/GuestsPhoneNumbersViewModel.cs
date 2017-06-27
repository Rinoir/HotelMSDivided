using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class GuestsPhoneNumbersViewModel
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        public int PhoneNumberTypeCode { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Phone number must be written in format +38(0__)-___-__-__")]
        public string PhoneNumber { get; set; }

        public virtual HotelGuestsViewModel HotelGuests { get; set; }
        public virtual PhoneNumbersTypesViewModel PhoneNumbersTypes { get; set; }
    }
}