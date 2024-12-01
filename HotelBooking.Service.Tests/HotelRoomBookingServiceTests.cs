using AutoFixture;
using HotelBooking.Common.Interfaces.DAL;
using HotelBooking.Common.Interfaces.Service;
using HotelBooking.Domain;
using Moq;

namespace HotelBooking.Service.Tests
{
    public class HotelRoomBookingServiceTests
    {
        private readonly IHotelRoomBookingService _sut;
        private readonly Mock<IHotelRoomBookingDAL> _dal;
        private readonly Fixture _fixture;
        public HotelRoomBookingServiceTests()
        {
            _dal = new Mock<IHotelRoomBookingDAL>();

            _sut = new HotelRoomBookingService(_dal.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_Returns_HotelRoomBooking()
        {
            var hotelRoomBooking = _fixture.Create<HotelRoomBooking?>();

            var bookingNumber = _fixture.Create<Guid>();

            _dal.Setup(x => x.Get(bookingNumber)).Returns(Task.FromResult(hotelRoomBooking));

            var result = await _sut.Get(bookingNumber);

            Assert.Equal(hotelRoomBooking?.Id, result?.Id);

            Assert.Equal(hotelRoomBooking?.Number, result?.Number);

            Assert.Equal(hotelRoomBooking?.HotelRoom?.Id, result?.HotelRoom?.Id);

            Assert.Equal(hotelRoomBooking?.NumberOccupants, result?.NumberOccupants);

            Assert.Equal(hotelRoomBooking?.StartDate, result?.StartDate);

            Assert.Equal(hotelRoomBooking?.EndDate, result?.EndDate);

        }


        [Fact]
        public async Task Book_Calls_DAL()
        {
            var hotelRoomId = _fixture.Create<int>();

            var numberOfPeople = _fixture.Create<int>();

            var startDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var endDate = DateOnly.FromDateTime(_fixture.Create<DateTime>());

            var bookingNumber = _fixture.Create<Guid?>();

            _dal.Setup(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate)).Returns(Task.FromResult(bookingNumber));

            var result = await _sut.Book(hotelRoomId, numberOfPeople, startDate,endDate);

            _dal.Verify(x => x.Book(hotelRoomId, numberOfPeople, startDate, endDate), Times.Once());

            Assert.Equal(result, bookingNumber);
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