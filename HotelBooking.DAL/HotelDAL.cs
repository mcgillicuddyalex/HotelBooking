using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.EF;
using HotelBooking.Domain;

namespace HotelBooking.DAL
{
    public class HotelDAL : IHotelDAL
    {
        private readonly IHotelContext _hotelContext;
        public HotelDAL(IHotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public IEnumerable<Hotel> GetHotelsByName(string name)
        {
            return _hotelContext.Hotels.Where(x => x.Name.Contains(name));
        }

        public void Seed()
        {
            for(var i = 0; i <5; i++)
                _hotelContext.Hotels.Add(new Hotel($"Hotel {i}", $"Location {i}"));

            _hotelContext.SaveChanges();
        }

        public void Reset()
        {
            _hotelContext.Hotels.RemoveRange(_hotelContext.Hotels);

            _hotelContext.SaveChanges();
        }
    }
}