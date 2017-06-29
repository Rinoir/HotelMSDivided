using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMSDivided.BLL.Interfaces
{
    interface IOrderStatusesService
    {
        string GetOrderStatus(int? id);
        int GetOrderStatusId(string name);
        void Dispose();
    }
}
