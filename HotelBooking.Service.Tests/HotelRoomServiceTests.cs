using AutoFixture;
using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Domain;
using Moq;

namespace HotelBooking.Service.Tests
{
    public class HotelRoomServiceTests
    {
        private readonly IHotelRoomService _sut;
        private readonly Mock<IHotelRoomDAL> _dal;
        private readonly Fixture _fixture;
        public HotelRoomServiceTests()
        {
            _dal = new Mock<IHotelRoomDAL>();

            _sut = new HotelRoomService(_dal.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public void GetAvailableRooms_Returns_HotelRooms()
        {
            var hotelRooms = _fixture.Build<HotelRoom>()
                .CreateMany();

            var startDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var endDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var numberOfPeople = _fixture.Create<int>();

            _dal.Setup(x => x.GetAvailableRooms(startDate, endDate, numberOfPeople)).Returns(hotelRooms);

            var results = _sut.GetAvailableRooms(startDate, endDate, numberOfPeople);

            Assert.Equal(results.Count(), hotelRooms.Count());

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
