
using CryptoCurrency.DBContext;
using CryptoCurrency.Repository;
using CryptoCurrency.Services.Interfaces;
using CryptoCurrency.Services.Realization;
using Microsoft.AspNetCore.Localization;

namespace CryptoCurrency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<DbContextApplication>();
            builder.Services.AddTransient<ICryptoCurrencyService, CryptoCurrencyRealization>();
            builder.Services.AddScoped<IRepository, RepositoryRealization>();
            builder.Services.AddSwaggerGen();
            //builder.Services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.DefaultRequestCulture = new RequestCulture("en-US");
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
