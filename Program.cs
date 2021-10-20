using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;
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
                DefaultBrowserRequestCache = BrowserRequestCache.NoCache,
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
