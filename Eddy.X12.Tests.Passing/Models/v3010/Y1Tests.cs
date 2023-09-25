using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*ehWINH*RTWqvF*6x*A*8t*rR*Vs*kV";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "ehWINH",
			ShipmentAvailabilityDate = "RTWqvF",
			StandardCarrierAlphaCode = "6x",
			TransportationMethodTypeCode = "A",
			EntityIdentifierCode = "8t",
			CityName = "rR",
			StateOrProvinceCode = "Vs",
			TariffServiceCode = "kV",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RTWqvF", true)]
	public void Validation_RequiredShipmentAvailabilityDate(string shipmentAvailabilityDate, bool isValidExpected)
	{
		var subject = new Y1_SpaceReservationRequest();
		//Required fields
		//Test Parameters
		subject.ShipmentAvailabilityDate = shipmentAvailabilityDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
