using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*aU*X*nJeH3mv9*j*B*gRe";

		var expected = new B1_BeginningSegmentForBookingOrPickUpDelivery()
		{
			StandardCarrierAlphaCode = "aU",
			ShipmentIdentificationNumber = "X",
			Date = "nJeH3mv9",
			ReservationActionCode = "j",
			YesNoConditionOrResponseCode = "B",
			ShipmentOrWorkAssignmentDeclineReasonCode = "gRe",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickUpDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickUpDelivery();
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
