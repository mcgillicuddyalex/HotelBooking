using AutoFixture;
using HotelBooking.Api.Controllers;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Moq;

namespace HotelBooking.Api.Tests
{
    public class BookingControllerTests
    {
        private readonly BookingController _sut;
        private readonly Mock<IHotelRoomBookingService> _hotelRoomBookingService;
        private readonly Fixture _fixture;

        public BookingControllerTests()
        {
            _hotelRoomBookingService = new Mock<IHotelRoomBookingService>();

            _sut = new BookingController(_hotelRoomBookingService.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_Calls_HotelRoomBookingService()
        {
            var bookingNumber = _fixture.Create<Guid>();

            var booking = _fixture.Create<HotelRoomBookingModel?>();

            _hotelRoomBookingService.Setup(x => x.Get(bookingNumber)).Returns(Task.FromResult(booking));

            var result = await _sut.Get(bookingNumber);

            _hotelRoomBookingService.Verify(x => x.Get(bookingNumber), Times.Once());

            Assert.Equal(booking?.Id, result?.Id);

            Assert.Equal(booking?.Number, result?.Number);

            Assert.Equal(booking?.HotelRoom?.Id, result?.HotelRoom?.Id);

            Assert.Equal(booking?.NumberOccupants, result?.NumberOccupants);

            Assert.Equal(booking?.StartDate, result?.StartDate);

            Assert.Equal(booking?.EndDate, result?.EndDate);
        }
    }
}