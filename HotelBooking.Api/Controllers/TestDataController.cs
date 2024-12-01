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
        public async Task<IActionResult> Seed()
        {
            await _hotelService.Seed();

            await _hotelRoomService.Seed();

            await _hotelRoomBookingService.Seed();

            return Ok();
        }

        [HttpPost("Reset", Name = "Reset")]
        public async Task<IActionResult> Reset()
        {
            await _hotelRoomBookingService.Reset();

            await _hotelRoomService.Reset();

            await _hotelService.Reset();

            return Ok();
        }
    }
}