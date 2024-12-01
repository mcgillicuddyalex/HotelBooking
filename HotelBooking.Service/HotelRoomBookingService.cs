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

        public async Task<HotelRoomBookingModel?> Get(Guid bookingNumber)
        {
            var booking = await _dal.Get(bookingNumber);

            return booking == null ? null : new HotelRoomBookingModel(booking);
        }

        public async Task<Guid?> Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate)
        {
            return await _dal.Book(hotelRoomId, numberOfPeople, startDate, endDate);
        }

        public async Task Seed()
        {
            await _dal.Seed();
        }

        public async Task Reset()
        {
            await _dal.Reset();
        }
    }
}