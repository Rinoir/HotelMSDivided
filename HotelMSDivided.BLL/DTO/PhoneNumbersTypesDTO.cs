using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class PhoneNumbersTypesDTO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public PhoneNumbersTypesDTO()
        //{
        //    this.GuestsPhoneNumbers = new HashSet<GuestsPhoneNumbersDTO>();
        //    this.StaffsPhoneNumbers = new HashSet<StaffsPhoneNumbersDTO>();
        //}

        public int PhoneNumberTypeCode { get; set; }
        [Display(Name = "Number Type")]
        public string PhoneNumberTypeName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GuestsPhoneNumbersDTO> GuestsPhoneNumbers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StaffsPhoneNumbersDTO> StaffsPhoneNumbers { get; set; }
    }
}
