using AutoFixture;
using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Domain;
using Moq;

namespace HotelBooking.Service.Tests
{
    public class HotelServiceTests
    {
        private readonly IHotelService _sut;
        private readonly Mock<IHotelDAL> _dal;
        private readonly Fixture _fixture;
        public HotelServiceTests() 
        {
            _dal = new Mock<IHotelDAL>();

            _sut = new HotelService(_dal.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetHotelsByName_Returns_Hotels()
        {
            var hotels = _fixture.Build<Hotel>()
                .CreateMany();

            var hotelName = "Hotel Name";

            _dal.Setup(x => x.GetHotelsByName(hotelName)).Returns(Task.FromResult(hotels));

            var results = await _sut.GetHotelsByName(hotelName);

            Assert.Equal(results.Count(), hotels.Count());

            for(var i = 0; i < results.Count(); i++)
            {
                var expected = hotels.Skip(i).First();

                var actual = results.Skip(i).First();

                Assert.Equal(expected.Id, actual.Id);

                Assert.Equal(expected.Name, actual.Name);

                Assert.Equal(expected.Location, actual.Location);
            }
        }

        [Fact]
        public void Seed_Calls_DAL()
        {
            _sut.Seed();

            _dal.Verify(x => x.Seed(), Times.Once());
        }

        [Fact]
        public void Reset_Calls_DAL()
        {
            _sut.Reset();

            _dal.Verify(x => x.Reset(), Times.Once());
        }
    }
}