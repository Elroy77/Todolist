using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebClients.services.Tasks;
using WebClients.services.Users;

namespace WebClients
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<ITaskApiClient, TaskApiClient>();
            builder.Services.AddTransient<IUserApiClient, UserApiClient>();
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000") });

            await builder.Build().RunAsync();
        }
    }
}
