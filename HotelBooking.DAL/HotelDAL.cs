using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL
{
    public class HotelDAL : IHotelDAL
    {
        private readonly IHotelContext _hotelContext;
        public HotelDAL(IHotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public async Task<IEnumerable<Hotel>> GetHotelsByName(string name)
        {
            return await _hotelContext.Hotels.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task Seed()
        {
            for(var i = 0; i <5; i++)
                _hotelContext.Hotels.Add(new Hotel($"Hotel {i}", $"Location {i}"));

            await _hotelContext.SaveChangesAsync();
        }

        public async Task Reset()
        {
            _hotelContext.Hotels.RemoveRange(_hotelContext.Hotels);

            await _hotelContext.SaveChangesAsync();
        }
    }
}