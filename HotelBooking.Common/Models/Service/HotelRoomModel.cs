using HotelBooking.Domain;

namespace HotelBooking.Common.Models.Service
{
    public class HotelRoomModel
    {
        public int Id { get; private set; }
        public string Number { get; private set; }
        public RoomType Type { get; private set; }
        public HotelModel? Hotel { get; private set; }
        public int Capacity { get; private set; }

        public HotelRoomModel(HotelRoom hotelRoom)
        {
            Id = hotelRoom.Id;
            Number = hotelRoom.Number;
            Type = hotelRoom.Type;
            Hotel = hotelRoom.Hotel == null ? null : new HotelModel(hotelRoom.Hotel);
            Capacity = hotelRoom.Capacity;
        }
    }
}
