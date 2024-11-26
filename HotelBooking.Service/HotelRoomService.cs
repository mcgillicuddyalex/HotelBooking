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
        public IEnumerable<HotelRoomModel> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople)
        {
            return _dal.GetAvailableRooms(startDate, endDate, numberOfPeople).Select(x => new HotelRoomModel(x));
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
