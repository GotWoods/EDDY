using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*YZ*z*B3Svj09P*o*D*g0Q";

		var expected = new B1_BeginningSegmentForBookingOrPickUpDelivery()
		{
			StandardCarrierAlphaCode = "YZ",
			ShipmentIdentificationNumber = "z",
			Date = "B3Svj09P",
			ReservationActionCode = "o",
			YesNoConditionOrResponseCode = "D",
			ShipmentOrWorkAssignmentDeclineReasonCode = "g0Q",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickUpDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickUpDelivery();
		subject.ShipmentIdentificationNumber = "z";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickUpDelivery();
		subject.StandardCarrierAlphaCode = "YZ";
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
