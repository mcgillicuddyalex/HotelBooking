using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain
{
    public class Hotel
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public Hotel()
        {

        }
        public Hotel(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
