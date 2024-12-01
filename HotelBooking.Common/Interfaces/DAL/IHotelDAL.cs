using HotelBooking.Domain;

namespace HotelBooking.Common.Interfaces.DAL
{
    public interface IHotelDAL
    {
        Task<IEnumerable<Hotel>> GetHotelsByName(string name);
        Task Seed();
        Task Reset();
    }
}
