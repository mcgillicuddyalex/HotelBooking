using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelService
    {
        public IEnumerable<HotelModel> GetHotelsByName(string name);
        void Seed();
        void Reset();
    }
}