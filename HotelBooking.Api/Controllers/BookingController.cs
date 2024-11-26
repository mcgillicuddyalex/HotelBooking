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
        public HotelRoomBookingModel? Get(Guid bookingNumber)
        {
            return _hotelRoomBookingService.Get(bookingNumber);
        }
    }
}