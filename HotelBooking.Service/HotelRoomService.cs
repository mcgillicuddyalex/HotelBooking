using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;

namespace HotelBooking.Service
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IHotelRoomDAL _dal;
        public HotelRoomService(IHotelRoomDAL hotelRoomDAL)
        {
            _dal = hotelRoomDAL;
        }
        public async Task<IEnumerable<HotelRoomModel>> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople)
        {
            var availableRooms = await _dal.GetAvailableRooms(startDate, endDate, numberOfPeople);

            return availableRooms.Select(x => new HotelRoomModel(x));
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
