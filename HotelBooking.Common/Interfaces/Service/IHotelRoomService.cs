using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelRoomService
    {
        Task<IEnumerable<HotelRoomModel>> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople);
        Task Seed();
        Task Reset();
    }
}