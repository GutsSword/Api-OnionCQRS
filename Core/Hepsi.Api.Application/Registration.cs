using FluentValidation;
using Hepsi.Api.Application.Bases;
using Hepsi.Api.Application.Behaviours;
using Hepsi.Api.Application.Exceptions;
using Hepsi.Api.Application.Features.Products.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Hepsi.Api.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleWare>();
            services.AddRulesFromAssemblyByContaining(assembly, typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyByContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(x => x.IsSubclassOf(type) && type != x).ToList();
            foreach(var item in types)
            {
                services.AddTransient(item);
            }

            return services;                
        }
    }
}
