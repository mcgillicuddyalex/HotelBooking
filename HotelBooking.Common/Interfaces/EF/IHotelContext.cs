using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Common.Interfaces.EF
{
    public interface IHotelContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<HotelRoom> HotelRooms { get; set; }
        DbSet<HotelRoomBooking> HotelRoomBookings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}