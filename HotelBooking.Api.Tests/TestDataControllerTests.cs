using HotelBooking.Api.Controllers;
using HotelBooking.Common.Interfaces.Service;
using Moq;

namespace HotelBooking.Api.Tests
{
    public class TestDataControllerTests
    {
        private readonly TestDataController _sut;
        private readonly Mock<IHotelService> _hotelService;
        private readonly Mock<IHotelRoomService> _hotelRoomService;
        private readonly Mock<IHotelRoomBookingService> _hotelRoomBookingService;

        public TestDataControllerTests()
        {
            _hotelService = new Mock<IHotelService>();

            _hotelRoomService = new Mock<IHotelRoomService>();

            _hotelRoomBookingService = new Mock<IHotelRoomBookingService>();

            _sut = new TestDataController(_hotelService.Object, _hotelRoomService.Object, _hotelRoomBookingService.Object);
        }

        [Fact]
        public void Seed_Calls_Service_Methods()
        {
            _sut.Seed();

            _hotelService.Verify(x => x.Seed(), Times.Once());

            _hotelRoomService.Verify(x => x.Seed(), Times.Once());

            _hotelRoomBookingService.Verify(x => x.Seed(), Times.Once());
        }

        [Fact]
        public void Reset_Calls_Service_Methods()
        {
            _sut.Reset();

            _hotelService.Verify(x => x.Reset(), Times.Once());

            _hotelRoomService.Verify(x => x.Reset(), Times.Once());

            _hotelRoomBookingService.Verify(x => x.Reset(), Times.Once());
        }
    }
}