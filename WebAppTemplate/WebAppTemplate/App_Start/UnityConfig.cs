using System;
using System.Data.Entity;
using System.Linq;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;
using Unity.RegistrationByConvention;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;
using WebAppTemplate.Service;
using WebAppTemplate.Service.Interface;

namespace WebAppTemplate
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            // Repository
            //container.RegisterType<IOrderRepo, OrderRepo>();
            //container.RegisterType<IOrder_DetailsRepo, Order_DetailsRepo>();

            ////// Service
            //container.RegisterType<IOrderService, OrderService>();
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterTypes
            (
              types: AllClasses.FromLoadedAssemblies().Where(x => x.Namespace.Contains("WebAppTemplate")),
              getFromTypes: WithMappings.FromMatchingInterface,
              getName: WithName.Default,
              getLifetimeManager: WithLifetime.Custom<TransientLifetimeManager>,
              getInjectionMembers: null,
              overwriteExistingMappings: true
            );
            container.RegisterType<DbContext, NorthwindEntities>(new PerRequestLifetimeManager());
           
        }
    }
}