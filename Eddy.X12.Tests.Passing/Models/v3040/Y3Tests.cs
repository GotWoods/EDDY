using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*6*3D*YtZRLr*zy403v*vypS39*I8*XLceb1*QTFw*u*07*0d";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "6",
			StandardCarrierAlphaCode = "3D",
			SailingDate = "YtZRLr",
			ETADate = "zy403v",
			StandardPointLocationCode = "vypS39",
			PierName = "I8",
			Date = "XLceb1",
			Time = "QTFw",
			TransportationMethodTypeCode = "u",
			TariffServiceCode = "07",
			TimeCode = "0d",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
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
	[InlineData("u", "QTFw", true)]
	[InlineData("u", "", false)]
	[InlineData("", "QTFw", true)]
	public void Validation_ARequiresBTransportationMethodTypeCode(string transportationMethodTypeCode, string time, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		subject.BookingNumber = "6";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
