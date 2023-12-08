using System;
using A10BLogging.Services;
using Microsoft.Extensions.DependencyInjection;

namespace A10BLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                var startup = new Startup();
                var serviceProvider = startup.ConfigureServices();
                var service = serviceProvider.GetService<IMainService>();

                service?.Invoke();
            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine(ex);
            }

        }
    }
}
