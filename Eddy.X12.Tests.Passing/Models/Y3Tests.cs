using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*Q*xr*weOijhfY*x8q4xm1L*rX1hM5*cC*gC5ylOVj*0HNw*r*cc*WK";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "Q",
			StandardCarrierAlphaCode = "xr",
			Date = "weOijhfY",
			Date2 = "x8q4xm1L",
			StandardPointLocationCode = "rX1hM5",
			PierName = "cC",
			Date3 = "gC5ylOVj",
			Time = "0HNw",
			TransportationMethodTypeCode = "r",
			TariffServiceCode = "cc",
			TimeCode = "WK",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "0HNw", true)]
	[InlineData("WK", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		subject.BookingNumber = "Q";
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
