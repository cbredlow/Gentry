using Microblog.Data.Services;
using Microblog.Data.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace MicroblogService.Extensions
{
    internal static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddSingleton<IMicroblogpostService, MicroblogpostService>();
        }
    }
}
