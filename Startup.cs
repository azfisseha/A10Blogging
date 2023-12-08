using A10BLogging.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10BLogging
{
    internal class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IBlogDBHandler, BlogDBHandler>();

            return services.BuildServiceProvider();
        }
    }
}
