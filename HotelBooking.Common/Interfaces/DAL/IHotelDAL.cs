using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelDAL
    {
        public IEnumerable<Hotel> GetHotelsByName(string name);
        void Seed();
        void Reset();
    }
}
