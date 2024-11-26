using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IHotelRoomService _hotelRoomService;
        private readonly IHotelRoomBookingService _hotelRoomBookingService;

        public RoomController(IHotelRoomService hotelRoomService, IHotelRoomBookingService hotelRoomBookingService)
        {
            _hotelRoomService = hotelRoomService;
            _hotelRoomBookingService = hotelRoomBookingService;
        }

        [HttpGet()]
        public IEnumerable<HotelRoomModel> GetAvailableRooms(DateOnly startDate, DateOnly endDate, int numberOfPeople)
        {
            return _hotelRoomService.GetAvailableRooms(startDate, endDate, numberOfPeople);
        }

        [HttpPost("{hotelRoomId}/Book")]
        public ActionResult BookRoom(int hotelRoomId, int numberOfPeople, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var bookingNumber = _hotelRoomBookingService.Book(hotelRoomId, numberOfPeople, startDate, endDate);

                return Ok(bookingNumber);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}