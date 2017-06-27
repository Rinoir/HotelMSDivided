using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelMSDivided.BLL.Services;
using HotelMSDivided.BLL.Interfaces;
using Ninject;

namespace HotelMSDivided.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IGuestsPhoneNumbersService>().To<GuestsPhoneNumbersService>();
            kernel.Bind<IHotelGuestsService>().To<HotelGuestsService>();
            kernel.Bind<IHotelRoomsService>().To<HotelRoomsService>();
            kernel.Bind<IHotelsRoomRegistrationsService>().To<HotelsRoomRegistrationsService>();
            kernel.Bind<IHotelStaffsService>().To<HotelStaffsService>();
            kernel.Bind<IOrdersRegistrationsService>().To<OrdersRegistrationsService>();
        }
    }
}