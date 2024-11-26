using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;

namespace HotelBooking.Service
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDAL _dal;
        public HotelService(IHotelDAL hotelDAL)
        {
            _dal = hotelDAL;
        }
        public IEnumerable<HotelModel> GetHotelsByName(string name)
        {
            return _dal.GetHotelsByName(name).Select(x => new HotelModel(x));
        }
        public void Seed()
        {
            _dal.Seed();
        }
        public void Reset()
        {
            _dal.Reset();
        }
    }
}