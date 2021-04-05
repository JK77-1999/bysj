using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using bysj.Domain.Abstract;
using bysj.Domain.Concrete;

namespace bysj.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
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

        public void AddBindings()
        {
            kernel.Bind<IMachinesRepository>().To<EFMachineRepository>();
            kernel.Bind<IStaffsRepository>().To<EFStaffRepository>();

            //kernel.Bind<IOrderProcessor>().To<DatabaseOrderProcessor>();

            //EmailSettings emailSettings = new EmailSettings();
            //kernel.Bind<IReadersRepository>().To<EFReadersRepository>().WithConstructorArgument("settings", emailSettings); ;
        }
    }
}