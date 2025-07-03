using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Models;
namespace BookStore.Tests.Setup;
public class IntegrationTestFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<BookStoreContext>)
            );

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Adicionar o banco de dados em memória
            services.AddDbContext<BookStoreContext>(options =>
                options.UseInMemoryDatabase("InMemoryDbForTesting"));
        });
    }
}