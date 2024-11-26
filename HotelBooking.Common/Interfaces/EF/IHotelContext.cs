using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Common.Interfaces.EF
{
    public interface IHotelContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomBooking> HotelRoomBookings { get; set; }
        int SaveChanges();
    }
}