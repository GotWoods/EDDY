using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*LMWSrV*j5QQxS*Vr*3*Z9*Do*OE*qt*wy4";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "LMWSrV",
			Date = "j5QQxS",
			StandardCarrierAlphaCode = "Vr",
			TransportationMethodTypeCode = "3",
			EntityIdentifierCode = "Z9",
			CityName = "Do",
			StateOrProvinceCode = "OE",
			TariffServiceCode = "qt",
			DateTimeQualifier = "wy4",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j5QQxS", "wy4", true)]
	[InlineData("j5QQxS", "", false)]
	[InlineData("", "wy4", false)]
	public void Validation_AllAreRequiredDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new Y1_SpaceReservationRequest();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
