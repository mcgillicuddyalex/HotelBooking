using HotelBooking.Domain;

namespace HotelBooking.Common.Models.Service
{
    public class HotelModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public HotelModel(Hotel hotel)
        {
            Id = hotel.Id;
            Name = hotel.Name;
            Location = hotel.Location;
        }
    }
}