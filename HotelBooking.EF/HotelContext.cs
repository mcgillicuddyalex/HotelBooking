using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.EF
{
    public class HotelContext : DbContext, IHotelContext
    {
        

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomBooking> HotelRoomBookings { get; set; }


        // MSSQL solution - removed in favour of Sql Lite that is easier to use

        //public readonly string _connectionString;

        //private readonly IConfiguration _configuration;

        //public HotelContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("HotelDatabase"));
        //}


        public string DbPath { get; }

        public HotelContext()
        {
            var projectRoot = Directory.GetCurrentDirectory();

            DbPath = Path.Join(projectRoot, "hotelBooking.db");
        }

        // The following configures EF to create a Sqlite database file in the solution folder
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}