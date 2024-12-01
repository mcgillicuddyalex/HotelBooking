using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IHotelRoomBookingService _hotelRoomBookingService;

        public BookingController(IHotelRoomBookingService hotelRoomBookingService)
        {
            _hotelRoomBookingService = hotelRoomBookingService;
        }

        [HttpGet("{bookingNumber}")]
        public async Task<HotelRoomBookingModel?> Get(Guid bookingNumber)
        {
            return await _hotelRoomBookingService.Get(bookingNumber);
        }
    }
}