using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*rMDKlw*1vNmhT*Uc*7*Np*Sy*OL*uU*IMl";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "rMDKlw",
			Date = "1vNmhT",
			StandardCarrierAlphaCode = "Uc",
			TransportationMethodTypeCode = "7",
			EntityIdentifierCode = "Np",
			CityName = "Sy",
			StateOrProvinceCode = "OL",
			TariffServiceCode = "uU",
			DateTimeQualifier = "IMl",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1vNmhT", "IMl", true)]
	[InlineData("1vNmhT", "", false)]
	[InlineData("", "IMl", false)]
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
