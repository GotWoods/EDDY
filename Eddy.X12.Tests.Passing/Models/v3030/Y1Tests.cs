using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class Y1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y1*c7VkRo*lu6cwe*YX*i*2Y*W2*ls*UL";

		var expected = new Y1_SpaceReservationRequest()
		{
			SailingFlightDateEstimated = "c7VkRo",
			ShipmentAvailabilityDate = "lu6cwe",
			StandardCarrierAlphaCode = "YX",
			TransportationMethodTypeCode = "i",
			EntityIdentifierCode = "2Y",
			CityName = "W2",
			StateOrProvinceCode = "ls",
			TariffServiceCode = "UL",
		};

		var actual = Map.MapObject<Y1_SpaceReservationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lu6cwe", true)]
	public void Validation_RequiredShipmentAvailabilityDate(string shipmentAvailabilityDate, bool isValidExpected)
	{
		var subject = new Y1_SpaceReservationRequest();
		//Required fields
		//Test Parameters
		subject.ShipmentAvailabilityDate = shipmentAvailabilityDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
