
using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.DAL;
using HotelBooking.EF;
using HotelBooking.Service;
using System.Text.Json.Serialization;

namespace HotelBooking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IHotelContext, HotelContext>();
            builder.Services.AddScoped<IHotelDAL, HotelDAL>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IHotelRoomDAL, HotelRoomDAL>();
            builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();
            builder.Services.AddScoped<IHotelRoomBookingDAL, HotelRoomBookingDAL>();
            builder.Services.AddScoped<IHotelRoomBookingService, HotelRoomBookingService>();

            builder.Services.AddControllers()
            .AddJsonOptions(opts =>
             {
                 var enumConverter = new JsonStringEnumConverter();
                 opts.JsonSerializerOptions.Converters.Add(enumConverter);
             });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

        public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HotelContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
