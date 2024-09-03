using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

namespace Bws.Client.Web.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static async Task<AppSettings?> GetAppConfiguration(this WebAssemblyHostBuilder builder)
        {
            var environment = builder.HostEnvironment.Environment;

            //builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //                      .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
            //var apiSettings = builder.Configuration.Get<ApiSettings>();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            var appSettingsPath = string.IsNullOrWhiteSpace(environment) ? "appsettings.json" : $"appsettings.{environment}.json";

            return await httpClient.GetFromJsonAsync<AppSettings>(appSettingsPath);
        }


        public static WebAssemblyHostBuilder SetupHttpClient(this WebAssemblyHostBuilder builder, ApiSettings? apiSettings)
        {
            var apiBaseAddres = apiSettings?.BaseUrl ?? builder.HostEnvironment.BaseAddress;
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddres) });

            return builder;
        }
    }
}
