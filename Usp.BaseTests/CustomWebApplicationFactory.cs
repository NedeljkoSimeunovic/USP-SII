using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Usp.BaseTests;

public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup>where TStartup : class
{
    public CustomWebApplicationFactory()
    {
        Task.Run(async () => { await DB.InitAsync("UspBazaZaTestiranj", 
                MongoClientSettings.FromConnectionString(
                "mongodb+srv://nedeljkosimeunovic21:rf0yY5vLarQaeC4W@cluster-usp.mswjr.mongodb.net/")); })
            .GetAwaiter()
            .GetResult();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IHostedService));
        });
    }
}