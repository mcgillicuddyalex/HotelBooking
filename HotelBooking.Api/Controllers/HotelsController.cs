using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<HotelModel>> GetByName(string name)
        {
            return await _hotelService.GetHotelsByName(name);
        }
    }
}
