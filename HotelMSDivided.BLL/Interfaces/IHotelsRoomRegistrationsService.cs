using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMSDivided.BLL.DTO;

namespace HotelMSDivided.BLL.Interfaces
{
    public interface IHotelsRoomRegistrationsService
    {
        IEnumerable<HotelsRoomRegistrationDTO> GetRegistrations();
        HotelsRoomRegistrationDTO GetRegistration(int? id);
        string GetPaymentMethodName(int? id);
        int GetPaymentMethodCode(string name);
        string GetStatusName(int? id);
        int GetStatusCode(string name);
        void Create(HotelsRoomRegistrationDTO registration);
        void Update(HotelsRoomRegistrationDTO registration);
        void Dispose();
    }
}
