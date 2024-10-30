using ResendReturnedCard.Services.Interfaces;
using ResendReturnedCard.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ResendReturnedCard
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IapiService, ApiService>();
            container.RegisterType<IwebApiInvoker, WebApiInvoker>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}