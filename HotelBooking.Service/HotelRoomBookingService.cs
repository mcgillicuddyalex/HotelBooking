using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;

namespace HotelBooking.Service
{
    public class HotelRoomBookingService : IHotelRoomBookingService
    {
        private readonly IHotelRoomBookingDAL _dal;
        public HotelRoomBookingService(IHotelRoomBookingDAL hotelRoomBookingDAL)
        {
            _dal = hotelRoomBookingDAL;
        }

        public HotelRoomBookingModel? Get(Guid bookingNumber)
        {
            var booking = _dal.Get(bookingNumber);

            return booking == null ? null : new HotelRoomBookingModel(booking);
        }

        public Guid? Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate)
        {
            return _dal.Book(hotelRoomId, numberOfPeople, startDate, endDate);
        }

        public void Seed()
        {
            _dal.Seed();
        }

        public void Reset()
        {
            _dal.Reset();
        }
    }
}