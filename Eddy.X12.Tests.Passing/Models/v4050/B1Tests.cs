using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*CR*p*REKkJieS*f*Q*tFN";

		var expected = new B1_BeginningSegmentForBookingOrPickUpDelivery()
		{
			StandardCarrierAlphaCode = "CR",
			ShipmentIdentificationNumber = "p",
			Date = "REKkJieS",
			ReservationActionCode = "f",
			YesNoConditionOrResponseCode = "Q",
			ShipmentOrWorkAssignmentDeclineReasonCode = "tFN",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickUpDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CR", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickUpDelivery();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
