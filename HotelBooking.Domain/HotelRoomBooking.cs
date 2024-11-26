using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain
{
    public class HotelRoomBooking
    {
        [Key]
        public int Id { get; set; }

        public Guid Number { get; private set; }

        public HotelRoom? HotelRoom { get; private set; }

        [ForeignKey(nameof(HotelRoom))]
        public int HotelRoomId { get; private set; }

        [Range(0,9)]
        public int NumberOccupants { get; private set; }

        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public bool ViolatesBooking(DateOnly requestedStartDate, DateOnly requestedEndDate)
        {
            if((requestedStartDate >= StartDate && requestedStartDate < EndDate) || 
                (requestedEndDate > StartDate && requestedStartDate <= StartDate))
            {
                return true;
            }
            return false;
        }

        public HotelRoomBooking()
        {

        }

        public HotelRoomBooking(int hotelRoomId, int numberOfOccupants, DateOnly startDate, DateOnly endDate)
        {
            Number = Guid.NewGuid();
            HotelRoomId = hotelRoomId;
            NumberOccupants = numberOfOccupants;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}