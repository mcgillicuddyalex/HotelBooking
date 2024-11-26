using HotelBooking.Domain;

namespace HotelBooking.Common.Models.Service
{
    public class HotelRoomBookingModel
    {
        public int Id { get; set; }

        public Guid Number { get; private set; }

        public HotelRoomModel? HotelRoom { get; private set; }

        public int NumberOccupants { get; private set; }

        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public HotelRoomBookingModel(HotelRoomBooking hotelRoomBooking)
        {
            Id = hotelRoomBooking.Id;
            Number = hotelRoomBooking.Number;
            HotelRoom = hotelRoomBooking.HotelRoom == null ? null : new HotelRoomModel(hotelRoomBooking.HotelRoom);
            NumberOccupants = hotelRoomBooking.NumberOccupants;
            StartDate = hotelRoomBooking.StartDate;
            EndDate = hotelRoomBooking.EndDate;
        }
    }
}
