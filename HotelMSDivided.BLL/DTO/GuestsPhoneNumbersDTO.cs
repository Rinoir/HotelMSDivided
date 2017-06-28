using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class GuestsPhoneNumbersDTO
    {
        public int Id { get; set; }
        public string GuestMail { get; set; }
        public int PhoneNumberTypeCode { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Phone number must be written in format +38(0__)-___-__-__")]
        public string PhoneNumber { get; set; }

        //public virtual HotelGuestsDTO HotelGuests { get; set; }
        public virtual PhoneNumbersTypesDTO PhoneNumbersTypes { get; set; }
    }
}
