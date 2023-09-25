using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y5*s";

		var expected = new Y5_SpaceBookingCancellation()
		{
			BookingNumber = "s",
		};

		var actual = Map.MapObject<Y5_SpaceBookingCancellation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y5_SpaceBookingCancellation();
		//Required fields
		//Test Parameters
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
