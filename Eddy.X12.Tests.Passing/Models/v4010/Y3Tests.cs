using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*e*FN*yBrgGU4W*ScirpjhV*p5rQEh*5W*Hu3Kl98h*muVq*0*0O*4P";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "e",
			StandardCarrierAlphaCode = "FN",
			Date = "yBrgGU4W",
			Date2 = "ScirpjhV",
			StandardPointLocationCode = "p5rQEh",
			PierName = "5W",
			Date3 = "Hu3Kl98h",
			Time = "muVq",
			TransportationMethodTypeCode = "0",
			TariffServiceCode = "0O",
			TimeCode = "4P",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
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
	[InlineData("0", "muVq", true)]
	[InlineData("0", "", false)]
	[InlineData("", "muVq", true)]
	public void Validation_ARequiresBTransportationMethodTypeCode(string transportationMethodTypeCode, string time, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		subject.BookingNumber = "e";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
