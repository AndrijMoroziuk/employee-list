

using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EmployeeList.Domain.Interfaces;
using EmployeeList.Infrastructure.Business;
using EmployeeList.Infrastructure.Data;
using EmployeeList.Services.Interfaces;

namespace EmployeeList.Web.Util
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
            // repository
            kernel.Bind<ITestModelRepository>().To<TestModelRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();


            // service
            kernel.Bind<ITestModelService>().To<TestModelService>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>();

        }
    }
}