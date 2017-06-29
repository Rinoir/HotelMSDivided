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
        IEnumerable<PaymentMethodsDTO> GetPaymentMethods();
        OrdersRegistrationDTO GetOrder(string login);
        OrdersRegistrationDTO GetOrder(int id);
        string GetPaymentMethodName(int? id);
        int GetPaymentMethodCode(string name);
        string GetStatusName(int? id);
        int GetStatusCode(string name);
        void MoveToRegistration(HotelsRoomRegistrationDTO registration);
        void Create(OrdersRegistrationDTO order);
        void Update(OrdersRegistrationDTO order);
        bool IsExists(string login);
        void Delete(int? id);
        void Dispose();
    }
}
