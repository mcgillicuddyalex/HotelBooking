using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; private set; }

        public string Number { get; private set; }

        public RoomType Type { get; private set; }

        public Hotel? Hotel { get; private set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; private set; }

        [Range(0,9)]
        public int Capacity { get; private set; }

        public HotelRoom()
        {

        }

        public HotelRoom(string number, RoomType roomType, int hotelId, int capacity)
        {
            Number = number;
            Type = roomType;
            HotelId = hotelId;
            Capacity = capacity;
        }
    }
}
