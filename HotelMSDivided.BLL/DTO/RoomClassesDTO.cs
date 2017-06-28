using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class RoomClassesDTO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public RoomClassesDTO()
        //{
        //    this.HotelRooms = new HashSet<HotelRoomsDTO>();
        //}

        public int RoomClassCode { get; set; }
        public string RoomClassName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<HotelRoomsDTO> HotelRooms { get; set; }
    }
}
