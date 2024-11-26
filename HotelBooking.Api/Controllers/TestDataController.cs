using HotelBooking.Common.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IHotelRoomService _hotelRoomService;
        private readonly IHotelRoomBookingService _hotelRoomBookingService;

        public TestDataController(IHotelService hotelService, IHotelRoomService hotelRoomService, IHotelRoomBookingService hotelRoomBookingService)
        {
            _hotelService = hotelService;
            _hotelRoomService = hotelRoomService;
            _hotelRoomBookingService = hotelRoomBookingService;
        }

        [HttpPost("Seed", Name = "Seed")]
        public void Seed()
        {
            _hotelService.Seed();
            _hotelRoomService.Seed();
            _hotelRoomBookingService.Seed();
        }

        [HttpPost("Reset", Name = "Reset")]
        public void Reset()
        {
            _hotelRoomBookingService.Reset();
            _hotelRoomService.Reset();
            _hotelService.Reset();
        }
    }
}