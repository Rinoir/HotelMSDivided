using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class HotelRoomsDTO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public HotelRoomsDTO()
        //{
        //    this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationDTO>();
        //    this.OrdersRegistration = new HashSet<OrdersRegistrationDTO>();
        //}

        public int RoomNumber { get; set; }
        public int RoomClassCode { get; set; }
        public int Floor { get; set; }
        public decimal DayCost { get; set; }
        public int RoomsAmount { get; set; }

        public virtual RoomClassesDTO RoomClasses { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<HotelsRoomRegistrationDTO> HotelsRoomRegistration { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<OrdersRegistrationDTO> OrdersRegistration { get; set; }
    }
}
