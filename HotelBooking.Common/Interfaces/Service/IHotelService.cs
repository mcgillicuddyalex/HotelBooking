using HotelBooking.Common.Models.Service;

namespace HotelBooking.Common.Interfaces.Service
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelModel>> GetHotelsByName(string name);
        Task Seed();
        Task Reset();
    }
}