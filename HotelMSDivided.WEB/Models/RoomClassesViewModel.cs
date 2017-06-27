using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class RoomClassesViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomClassesViewModel()
        {
            this.HotelRooms = new HashSet<HotelRoomsViewModel>();
        }

        public int RoomClassCode { get; set; }
        [Display(Name = "Room class")]
        public string RoomClassName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoomsViewModel> HotelRooms { get; set; }
    }
}