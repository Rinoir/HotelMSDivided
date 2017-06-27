using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IOrdersRegistrationsService
    {
        IEnumerable<OrdersRegistrationDTO> GetOrders();
        void Create(OrdersRegistrationDTO order);
        void Update(OrdersRegistrationDTO order);
        void Delete(int? id);
        void Dispose();
    }
}
