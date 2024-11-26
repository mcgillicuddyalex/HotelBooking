using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelRoomBookingService
    {
        public HotelRoomBookingModel? Get(Guid bookingNumber);
        public Guid? Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate);
        void Seed();
        void Reset();
    }
}