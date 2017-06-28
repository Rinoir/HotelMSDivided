using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class HotelGuestsViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelGuestsViewModel()
        {
            this.GuestPassport = new GuestPassportsViewModel();
            this.GuestsPhoneNumbers = new HashSet<GuestsPhoneNumbersViewModel>();
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationViewModel>();
            this.OrdersRegistration = new HashSet<OrdersRegistrationViewModel>();
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
        public virtual GuestPassportsViewModel GuestPassport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestsPhoneNumbersViewModel> GuestsPhoneNumbers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationViewModel> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersRegistrationViewModel> OrdersRegistration { get; set; }
    }
}