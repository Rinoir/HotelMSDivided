using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class PhoneNumbersTypesViewModel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public PhoneNumbersTypesViewModel()
        //{
        //    this.GuestsPhoneNumbers = new HashSet<GuestsPhoneNumbersViewModel>();
        //    this.StaffsPhoneNumbers = new HashSet<StaffsPhoneNumbersViewModel>();
        //}

        public int PhoneNumberTypeCode { get; set; }
        [Display(Name = "Number Type")]
        public string PhoneNumberTypeName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GuestsPhoneNumbersViewModel> GuestsPhoneNumbers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StaffsPhoneNumbersViewModel> StaffsPhoneNumbers { get; set; }
    }
}