using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*f61mXZsZ*npNs745Q*Ej*F*Y5*nt*39*TA*wTu";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "f61mXZsZ",
			Date = "npNs745Q",
			StandardCarrierAlphaCode = "Ej",
			TransportationMethodTypeCode = "F",
			EntityIdentifierCode = "Y5",
			CityName = "nt",
			StateOrProvinceCode = "39",
			TariffServiceCode = "TA",
			DateTimeQualifier = "wTu",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("npNs745Q", "wTu", true)]
	[InlineData("", "wTu", false)]
	[InlineData("npNs745Q", "", false)]
	public void Validation_AllAreRequiredDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new Y1_SpaceReservationRequest();
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
