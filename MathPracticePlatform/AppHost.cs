using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPracticePlatform.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MathPracticePlatform
{
    public static class AppHost
    {
        public static IServiceProvider BuildHost()
        {
            var services = new ServiceCollection();

            // voeg hier de services toe die je nodig hebt
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
