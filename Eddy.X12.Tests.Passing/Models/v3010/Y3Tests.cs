using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*d*Wj*lw48lM*swEsY4*aX3EgO*pb*J7dWZ5*9muw";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "d",
			StandardCarrierAlphaCode = "Wj",
			SailingDate = "lw48lM",
			ETADate = "swEsY4",
			StandardPointLocationCode = "aX3EgO",
			PierName = "pb",
			RequiredPierDate = "J7dWZ5",
			LoadTime = "9muw",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		//Test Parameters
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
