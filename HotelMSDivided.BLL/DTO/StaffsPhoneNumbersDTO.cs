using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class StaffsPhoneNumbersDTO
    {
        public int Id { get; set; }
        public string StaffMail { get; set; }
        public int PhoneNumberTypeCode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual HotelStaffDTO HotelStaff { get; set; }
        public virtual PhoneNumbersTypesDTO PhoneNumbersTypes { get; set; }
    }
}
