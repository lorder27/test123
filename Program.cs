using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudSurf
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient(sp => new HttpClient(new DefaultBrowserOptionsMessageHandler(new HttpClientHandler()) // new HttpClientHandler() in .NET 5.0
            {
                DefaultBrowserRequestCache = BrowserRequestCache.Reload,
                DefaultBrowserRequestCredentials = BrowserRequestCredentials.Include,
                DefaultBrowserRequestMode = BrowserRequestMode.Cors,
            })
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });
            await builder.Build().RunAsync();
        }
    }
}
