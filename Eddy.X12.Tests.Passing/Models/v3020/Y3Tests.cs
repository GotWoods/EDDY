using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*f*JI*kfGCr8*YryfDy*U8NQqo*JU*dvxbBm*sRcF";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "f",
			StandardCarrierAlphaCode = "JI",
			SailingDate = "kfGCr8",
			ETADate = "YryfDy",
			StandardPointLocationCode = "U8NQqo",
			PierName = "JU",
			Date = "dvxbBm",
			Time = "sRcF",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		//Test Parameters
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
