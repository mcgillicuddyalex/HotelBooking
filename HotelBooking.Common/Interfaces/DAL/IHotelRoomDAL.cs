using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelRoomDAL
    {
        public IEnumerable<HotelRoom> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople);
        void Seed();
        void Reset();
    }
}
