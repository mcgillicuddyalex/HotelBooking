using AutoFixture;
using HotelBooking.Api.Controllers;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelBooking.Api.Tests
{
    public class RoomControllerTests
    {
        private readonly RoomController _sut;
        private readonly Mock<IHotelRoomService> _hotelRoomService;
        private readonly Mock<IHotelRoomBookingService> _hotelRoomBookingService;
        private readonly Fixture _fixture;

        public RoomControllerTests()
        {
            _hotelRoomService = new Mock<IHotelRoomService>();

            _hotelRoomBookingService = new Mock<IHotelRoomBookingService>();

            _sut = new RoomController(_hotelRoomService.Object, _hotelRoomBookingService.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public void GetAvailableRooms_Calls_HotelRoomService()
        {
            var startDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var endDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var numberOfPeople = _fixture.Create<int>();

            var hotelRooms = _fixture.CreateMany<HotelRoomModel>();

            _hotelRoomService.Setup(x => x.GetAvailableRooms(startDate, endDate, numberOfPeople)).Returns(hotelRooms);

            var results = _sut.GetAvailableRooms(startDate, endDate, numberOfPeople);

            _hotelRoomService.Verify(x => x.GetAvailableRooms(startDate, endDate, numberOfPeople), Times.Once());

            for (var i = 0; i < results.Count(); i++) 
            {
                var expected = hotelRooms.Skip(i).First();

                var actual = results.Skip(i).First();

                Assert.Equal(expected.Id, actual.Id);

                Assert.Equal(expected.Type, actual.Type);

                Assert.Equal(expected.Number, actual.Number);

                Assert.Equal(expected.Hotel?.Id, actual.Hotel?.Id);

                Assert.Equal(expected.Capacity, actual.Capacity);
            }
        }


        [Fact]
        public void BookRoom_Calls_HotelRoomBookingService()
        {
            var hotelRoomId = _fixture.Create<int>();

            var startDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var endDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var numberOfPeople = _fixture.Create<int>();

            var bookingNumber = _fixture.Create<Guid?>();

            _hotelRoomBookingService.Setup(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate)).Returns(bookingNumber);

            var result = _sut.BookRoom(hotelRoomId, numberOfPeople, startDate, endDate);

            _hotelRoomBookingService.Verify(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate), Times.Once());

            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(((OkObjectResult)result).Value, bookingNumber);
        }

        [Fact]
        public void BookRoom_With_InvalidRequest_Returns_BadRequest()
        {
            var hotelRoomId = _fixture.Create<int>();

            var startDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var endDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var numberOfPeople = _fixture.Create<int>();

            _hotelRoomBookingService.Setup(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate)).Throws<Exception>();

            var result = _sut.BookRoom(hotelRoomId, numberOfPeople, startDate, endDate);

            _hotelRoomBookingService.Verify(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate), Times.Once());

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}