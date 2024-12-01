using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelRoomDAL
    {
        Task<IEnumerable<HotelRoom>> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople);
        Task Seed();
        Task Reset();
    }
}
