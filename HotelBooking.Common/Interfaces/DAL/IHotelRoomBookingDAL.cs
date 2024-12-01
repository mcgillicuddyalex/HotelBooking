using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelRoomBookingDAL
    {
        Task<HotelRoomBooking?> Get(Guid bookingNumber);
        Task<Guid?> Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate);
        Task Seed();
        Task Reset();
    }
}