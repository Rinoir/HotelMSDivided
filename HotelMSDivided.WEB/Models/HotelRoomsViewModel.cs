using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class HotelRoomsViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelRoomsViewModel()
        {
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationViewModel>();
            this.OrdersRegistration = new HashSet<OrdersRegistrationViewModel>();
        }

        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }
        public int RoomClassCode { get; set; }
        public int Floor { get; set; }
        [Display(Name = "Cost per day")]
        [DataType(DataType.Currency)]
        public decimal DayCost { get; set; }
        [Display(Name = "Rooms amount")]
        public int RoomsAmount { get; set; }

        public virtual RoomClassesViewModel RoomClasses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationViewModel> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersRegistrationViewModel> OrdersRegistration { get; set; }
    }
}