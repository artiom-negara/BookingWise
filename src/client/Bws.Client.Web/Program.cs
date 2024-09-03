using Bws.Client.Web.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Bws.Client.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var appSettings = await builder.GetAppConfiguration();
            
            builder.SetupHttpClient(appSettings?.ApiSettings);

            await builder.Build().RunAsync();
        }
    }
}
