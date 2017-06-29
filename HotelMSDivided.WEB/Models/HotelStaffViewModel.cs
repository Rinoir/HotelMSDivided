using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class HotelStaffViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelStaffViewModel()
        {
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationViewModel>();
            this.StaffsPassport = new StaffsPassportsViewModel();
            this.StaffsPhoneNumbers = new HashSet<StaffsPhoneNumbersViewModel>();
        }

        [Display(Name = "Employee login")]
        public string StaffMail { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PositionCode { get; set; }
        public decimal Salary { get; set; }
        public string Schedule { get; set; }

        public virtual EmployeesPositionsViewModel EmployeesPositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationViewModel> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual StaffsPassportsViewModel StaffsPassport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffsPhoneNumbersViewModel> StaffsPhoneNumbers { get; set; }
    }
}