using FluentValidation;
using Hepsi.Api.Application.Behaviours;
using Hepsi.Api.Application.Exceptions;
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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        }
    }
}
