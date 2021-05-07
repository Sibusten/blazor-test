using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sibusten.BlazorTest.Models;
using Sibusten.BlazorTest.Services;

namespace Sibusten.BlazorTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddSingleton<Ticker>()

                .AddSingleton<BrowsingTime>()
                .AddSingleton<BrowsingTimeCounter>()

                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })

                ;

            await builder.Build().RunAsync();
        }
    }
}
