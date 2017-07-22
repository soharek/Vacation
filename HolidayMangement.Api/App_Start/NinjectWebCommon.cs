using AutoMapper;
using HolidayMangement.Infrastructure.Mapper;
using HolidayMangement.Infrastructure.Repository;
using HolidayMangement.Infrastructure.Services.AbstractServices;
using HolidayMangement.Infrastructure.Services.Concrete;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HolidayMangement.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HolidayMangement.Api.App_Start.NinjectWebCommon), "Stop")]

namespace HolidayMangement.Api.App_Start
{
    using HolidayManagement.Core.Repesository;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject.Web.WebApi;
    using Ninject.Web.Mvc;
    using HolidayManagement.Core.Repesository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
               
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();
            kernel.Bind<IMapper>().ToConstant(MapperConfig.Configure()).InSingletonScope();
            kernel.Bind<IEmployeeRepository>().To<EmplyeeInMemoryRepository>().InRequestScope();
        }        
    }
}
