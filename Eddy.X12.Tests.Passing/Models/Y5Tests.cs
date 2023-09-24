using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y5*8";

		var expected = new Y5_SpaceBookingCancellation()
		{
			BookingNumber = "8",
		};

		var actual = Map.MapObject<Y5_SpaceBookingCancellation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y5_SpaceBookingCancellation();
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
