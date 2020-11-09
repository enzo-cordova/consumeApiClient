using ConsoleAppConsumeApi.Contract;
using ConsoleAppConsumeApi.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppConsumeApi
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient<PersonApiClient>(c =>
                    {
                        c.BaseAddress = new Uri("http://dummy.restapiexample.com/");
                        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                        c.DefaultRequestHeaders.Add("User-Agent", "ConsoleAppConsumeApi-Sample");
                    });
                    services.AddScoped<IPersonApiClient, PersonApiClient>();
                    services.AddScoped<IInputTestClient, InputTestClient>();
                    services.AddScoped<IHttpWrapperClient, HttpWrapperClient>();
                    services.AddScoped<IHttpWrapperClient>(provider =>
                        new HttpWrapperClient(provider.GetService<IHttpClientFactory>(), "PersonApiClient"));

                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<IInputTestClient>();
                    var result = await myService.Run();

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured: " + ex.Message);
                }
            }

            return 0;
        }

    }
}
