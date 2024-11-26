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

        public HotelRoomBooking? Get(Guid bookingNumber)
        {
            return _hotelContext.HotelRoomBookings.Include(x => x.HotelRoom.Hotel).FirstOrDefault(x => x.Number == bookingNumber);
        }

        public Guid? Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate)
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

                _hotelContext.SaveChanges();

                return hotelRoomBooking.Number;
            }
        }

        public void Seed()
        {
            var hotelRooms = _hotelContext.HotelRooms;

            var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5));

            var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5));

            foreach (var hotelRoom in hotelRooms)
                _hotelContext.HotelRoomBookings.Add(new HotelRoomBooking(hotelRoom.Id, hotelRoom.Capacity, startDate, endDate));

            _hotelContext.SaveChanges();
        }

        public void Reset()
        {
            _hotelContext.HotelRoomBookings.RemoveRange(_hotelContext.HotelRoomBookings);

            _hotelContext.SaveChanges();
        }
    }
}