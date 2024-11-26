using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelRoomBookingDAL
    {
        public HotelRoomBooking? Get(Guid bookingNumber);
        public Guid? Book(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate);
        void Seed();
        void Reset();
    }
}