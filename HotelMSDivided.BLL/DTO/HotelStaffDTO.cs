using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class HotelStaffDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelStaffDTO()
        {
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationDTO>();
            this.StaffsPassports = new HashSet<StaffsPassportsDTO>();
            this.StaffsPhoneNumbers = new HashSet<StaffsPhoneNumbersDTO>();
        }

        public string StaffMail { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PositionCode { get; set; }
        public decimal Salary { get; set; }
        public string Schedule { get; set; }

        public virtual EmployeesPositionsDTO EmployeesPositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationDTO> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffsPassportsDTO> StaffsPassports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffsPhoneNumbersDTO> StaffsPhoneNumbers { get; set; }
    }
}
