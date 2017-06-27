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
        void Create(HotelsRoomRegistrationDTO registration);
        void Update(HotelsRoomRegistrationDTO registration);
        void Dispose();
    }
}
