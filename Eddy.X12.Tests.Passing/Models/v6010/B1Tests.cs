using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*Ne*K*Z1VASggR*q*k*gEU*s5";

		var expected = new B1_BeginningSegmentForBookingOrPickupDelivery()
		{
			StandardCarrierAlphaCode = "Ne",
			ShipmentIdentificationNumber = "K",
			Date = "Z1VASggR",
			ReservationActionCode = "q",
			YesNoConditionOrResponseCode = "k",
			ShipmentOrWorkAssignmentDeclineReasonCode = "gEU",
			ShipmentMethodOfPayment = "s5",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickupDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ne", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickupDelivery();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
