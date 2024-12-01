using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL
{
    public class HotelRoomBookingDAL : IHotelRoomBookingDAL
    {
        private readonly IHotelContext _hotelContext;
        public HotelRoomBookingDAL(IHotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<HotelRoomBooking?> Get(Guid bookingNumber)
        {
            return await _hotelContext.HotelRoomBookings.Include(x => x.HotelRoom.Hotel).FirstOrDefaultAsync(x => x.Number == bookingNumber);
        }

        public async Task<Guid?> Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate)
        {
            var hotelRoomBooking = new HotelRoomBooking(hotelRoomId, numberOfPeople, startDate, endDate);

            if (!_hotelContext.HotelRooms.Any(x => x.Id == hotelRoomId))
                throw new Exception("Hotel Room doesn't exist");
            if (_hotelContext.HotelRooms.Any(x => x.Id == hotelRoomId && x.Capacity < numberOfPeople))
                throw new Exception("Hotel Room cannot be booked for this number of people");
            else if (_hotelContext.HotelRoomBookings.ToList().Any(x => x.HotelRoomId == hotelRoomId && x.ViolatesBooking(startDate, endDate)))
                throw new Exception("Hotel Room is already booked for these dates");
            else
            {
                _hotelContext.HotelRoomBookings.Add(hotelRoomBooking);

                await _hotelContext.SaveChangesAsync();

                return hotelRoomBooking.Number;
            }
        }

        public async Task Seed()
        {
            var hotelRooms = _hotelContext.HotelRooms;

            var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5));

            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5));

            foreach (var hotelRoom in hotelRooms)
                _hotelContext.HotelRoomBookings.Add(new HotelRoomBooking(hotelRoom.Id, hotelRoom.Capacity, startDate, endDate));

            await _hotelContext.SaveChangesAsync();
        }

        public async Task Reset()
        {
            _hotelContext.HotelRoomBookings.RemoveRange(_hotelContext.HotelRoomBookings);

            await _hotelContext.SaveChangesAsync();
        }
    }
}