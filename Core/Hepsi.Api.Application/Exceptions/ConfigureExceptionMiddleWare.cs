using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Exceptions
{
    public static class ConfigureExceptionMiddleWare
    {
        public static void ConfigureExceptionHandlingMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
        }
    }
}
