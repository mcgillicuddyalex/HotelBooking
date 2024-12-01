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
        public async Task<IEnumerable<HotelModel>> GetHotelsByName(string name)
        {
            var hotelRooms = await _dal.GetHotelsByName(name);
                
            return hotelRooms.Select(x => new HotelModel(x));
        }
        public async Task Seed()
        {
            await _dal.Seed();
        }
        public async Task Reset()
        {
            await _dal.Reset();
        }
    }
}