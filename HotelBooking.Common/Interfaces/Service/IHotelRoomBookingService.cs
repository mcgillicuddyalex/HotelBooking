using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelRoomBookingService
    {
        Task<HotelRoomBookingModel?> Get(Guid bookingNumber);
        Task<Guid?> Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate);
        Task Seed();
        Task Reset();
    }
}