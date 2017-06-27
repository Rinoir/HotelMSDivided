using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class StaffsPassportsDTO
    {
        public int Id { get; set; }
        public string StaffMail { get; set; }
        public string PassportSerialNumber { get; set; }
        public int PassportNumber { get; set; }

        public virtual HotelStaffDTO HotelStaff { get; set; }
    }
}
