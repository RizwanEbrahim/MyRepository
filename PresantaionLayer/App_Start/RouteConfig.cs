using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using BusinessLogicLayer.BusinessServices;
using DataAccessLayer.Repository;
using DataAccessLayer.Model;
namespace PresantaionLayer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Question", action = "AllQuestions", id = UrlParameter.Optional }
            );
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>();
            builder.RegisterType<AnswerService>().As<IAnswerService>();
            builder.RegisterType<DatabaseContext>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
