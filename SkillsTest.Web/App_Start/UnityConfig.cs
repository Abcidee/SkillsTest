using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using SkillsTest.Domain.Services;

namespace SkillsTest.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ITicketService, TicketService>();
            container.RegisterType<IUserService, UserService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}