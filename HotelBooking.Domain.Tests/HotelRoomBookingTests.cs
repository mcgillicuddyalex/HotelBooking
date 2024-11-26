namespace HotelBooking.Domain.Tests
{
    public class HotelRoomBookingTests
    {
        [Theory]
        [InlineData(11, 15, 5, 10, false)]
        [InlineData(10, 15, 5, 10, false)]
        [InlineData(9, 10, 5, 10, true)]
        [InlineData(4, 6, 5, 10, true)]
        [InlineData(0, 5, 5, 10, false)]
        public void ViolatesBooking(int requestedStartDateIncrement, int requestedEndDateIncrement, int bookingStartDateIncrement, int bookingEndDateIncrement, bool expectedResult)
        {
            var bookingStartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(bookingStartDateIncrement));

            var bookingEndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(bookingEndDateIncrement));

            var sut = new HotelRoomBooking(1, 1, bookingStartDate, bookingEndDate);

            var requestedStartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(requestedStartDateIncrement));

            var requestedEndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(requestedEndDateIncrement));

            var actualResult = sut.ViolatesBooking(requestedStartDate, requestedEndDate);

            Assert.Equal(actualResult, expectedResult);
        }
    }
}