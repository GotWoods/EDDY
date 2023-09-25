using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*njNRmbXk*Ohhdp9b0*lo*a*S7*bx*bk*xF*KmK";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "njNRmbXk",
			Date = "Ohhdp9b0",
			StandardCarrierAlphaCode = "lo",
			TransportationMethodTypeCode = "a",
			EntityIdentifierCode = "S7",
			CityName = "bx",
			StateOrProvinceCode = "bk",
			TariffServiceCode = "xF",
			DateTimeQualifier = "KmK",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ohhdp9b0", "KmK", true)]
	[InlineData("Ohhdp9b0", "", false)]
	[InlineData("", "KmK", false)]
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
