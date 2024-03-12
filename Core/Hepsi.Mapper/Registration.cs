using Hepsi.Api.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Hepsi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,AutoMapper.Mapper>();
        }
    }
}
