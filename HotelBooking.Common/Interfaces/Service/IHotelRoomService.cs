using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelRoomService
    {
        public IEnumerable<HotelRoomModel> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople);
        void Seed();
        void Reset();
    }
}