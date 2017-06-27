using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMSDivided.WEB.Models
{
    public class PaymentMethodsViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentMethodsViewModel()
        {
            this.HotelsRoomRegistration = new HashSet<HotelsRoomRegistrationViewModel>();
            this.OrdersRegistration = new HashSet<OrdersRegistrationViewModel>();
        }

        public int PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelsRoomRegistrationViewModel> HotelsRoomRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersRegistrationViewModel> OrdersRegistration { get; set; }
    }
}