using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class HotelGuestsDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelGuestsDTO()
        {
            this.GuestPassport = new GuestPassportsDTO();
            this.GuestsPhoneNumbers = new HashSet<GuestsPhoneNumbersDTO>();
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationDTO>();
            this.OrdersRegistration = new HashSet<OrdersRegistrationDTO>();
        }

        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Login is not valid")]
        [Display(Name = "Login")]
        public string GuestMail { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(40, MinimumLength = 1)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        public string Patronymic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual GuestPassportsDTO GuestPassport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestsPhoneNumbersDTO> GuestsPhoneNumbers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationDTO> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersRegistrationDTO> OrdersRegistration { get; set; }
    }
}
