using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*B*W1*k9vlHb*J1HbBM*TUq1hq*qg*HTL7se*Fhjh*C*ki*Mn";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "B",
			StandardCarrierAlphaCode = "W1",
			Date = "k9vlHb",
			Date2 = "J1HbBM",
			StandardPointLocationCode = "TUq1hq",
			PierName = "qg",
			Date3 = "HTL7se",
			Time = "Fhjh",
			TransportationMethodTypeCode = "C",
			TariffServiceCode = "ki",
			TimeCode = "Mn",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		//Test Parameters
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "Fhjh", true)]
	[InlineData("C", "", false)]
	[InlineData("", "Fhjh", true)]
	public void Validation_ARequiresBTransportationMethodTypeCode(string transportationMethodTypeCode, string time, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		subject.BookingNumber = "B";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
