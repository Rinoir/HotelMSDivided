using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using HotelMSDivided.DAL.Repositories;
using HotelMSDivided.DAL.Interfaces;


namespace HotelMSDivided.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ContextUnitOfWork>();
        }
    }
}
