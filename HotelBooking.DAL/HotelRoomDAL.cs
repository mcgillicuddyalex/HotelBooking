using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL
{
    public class HotelRoomDAL : IHotelRoomDAL
    {
        private readonly IHotelContext _hotelContext;

        public HotelRoomDAL(IHotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<IEnumerable<HotelRoom>> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople)
        {
            var validHotelRooms = await _hotelContext.HotelRooms.Include(x => x.Hotel).Where(x => x.Capacity >= numberOfPeople).ToListAsync();

            var validHotelRoomIds = validHotelRooms.Select(x => x.Id);

            var hotelRoomBookings = await _hotelContext.HotelRoomBookings
                .Where(x => validHotelRoomIds.Contains(x.HotelRoomId))
                .ToListAsync();

            var clashingHotelRoomBookings = hotelRoomBookings
                .Where(x => x.ViolatesBooking(startDate, endDate))
                .Select(x => x.HotelRoomId);

            return validHotelRooms.Where(x => !clashingHotelRoomBookings.Contains(x.Id));
        }

        public async Task Seed()
        {
            var hotels = _hotelContext.Hotels;

            var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5));

            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5));

            foreach (var hotel in hotels)
            {
                for (var i = 0; i < 5; i++)
                    _hotelContext.HotelRooms.Add(new HotelRoom($"Room {i}", (RoomType)(i%3), hotel.Id, 5));
            }

            await _hotelContext.SaveChangesAsync();
        }

        public async Task Reset()
        {
            _hotelContext.HotelRooms.RemoveRange(_hotelContext.HotelRooms);

            await _hotelContext.SaveChangesAsync();
        }
    }
}