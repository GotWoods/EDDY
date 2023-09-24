using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*ZS*O*LfMHbLMZ*q*u*2Kc*xh";

		var expected = new B1_BeginningSegmentForBookingOrPickupDelivery()
		{
			StandardCarrierAlphaCode = "ZS",
			ShipmentIdentificationNumber = "O",
			Date = "LfMHbLMZ",
			ReservationActionCode = "q",
			YesNoConditionOrResponseCode = "u",
			ShipmentOrWorkAssignmentDeclineReasonCode = "2Kc",
			ShipmentMethodOfPaymentCode = "xh",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickupDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickupDelivery();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
