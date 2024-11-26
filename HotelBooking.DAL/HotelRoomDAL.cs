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

        public IEnumerable<HotelRoom> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople)
        {
            var validHotelRooms = _hotelContext.HotelRooms.Include(x => x.Hotel).Where(x => x.Capacity >= numberOfPeople).ToList();

            var validHotelRoomIds = validHotelRooms.Select(x => x.Id);

            var hotelRoomBookings = _hotelContext.HotelRoomBookings
                .ToList()
                .Where(x => validHotelRoomIds.Contains(x.HotelRoomId) && x.ViolatesBooking(startDate, endDate))
                .Select(x => x.HotelRoomId);

            return validHotelRooms.Where(x => !hotelRoomBookings.Contains(x.Id));
        }

        public void Seed()
        {
            var hotels = _hotelContext.Hotels;

            var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5));

            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5));

            foreach (var hotel in hotels)
            {
                for (var i = 0; i < 5; i++)
                    _hotelContext.HotelRooms.Add(new HotelRoom($"Room {i}", (RoomType)(i%3), hotel.Id, 5));
            }

            _hotelContext.SaveChanges();
        }

        public void Reset()
        {
            _hotelContext.HotelRooms.RemoveRange(_hotelContext.HotelRooms);
            _hotelContext.SaveChanges();
        }
    }
}