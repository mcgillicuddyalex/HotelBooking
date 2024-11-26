using AutoFixture;
using HotelBooking.Api.Controllers;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Common.Models.Service;
using Moq;

namespace HotelBooking.Api.Tests
{
    public class HotelsControllerTests
    {
        private readonly HotelsController _sut;
        private readonly Mock<IHotelService> _hotelService;
        private readonly Fixture _fixture;

        public HotelsControllerTests()
        {
            _hotelService = new Mock<IHotelService>();

            _sut = new HotelsController(_hotelService.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public void GetByName_Calls_HotelService()
        {
            var name = _fixture.Create<string>();

            var hotels = _fixture.CreateMany<HotelModel>();

            _hotelService.Setup(x => x.GetHotelsByName(name)).Returns(hotels);

            var results = _sut.GetByName(name);

            _hotelService.Verify(x => x.GetHotelsByName(name), Times.Once());

            for (var i = 0; i < results.Count(); i++)
            {
                var expected = hotels.Skip(i).First();

                var actual = results.Skip(i).First();

                Assert.Equal(expected.Id, actual.Id);

                Assert.Equal(expected.Name, actual.Name);

                Assert.Equal(expected.Location, actual.Location);
            }
        }
    }
}