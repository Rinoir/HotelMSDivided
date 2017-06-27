using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.DTO
{
    public class PaymentMethodsDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentMethodsDTO()
        {
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationDTO>();
            this.OrdersRegistration = new HashSet<OrdersRegistrationDTO>();
        }

        public int PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationDTO> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersRegistrationDTO> OrdersRegistration { get; set; }
    }
}
