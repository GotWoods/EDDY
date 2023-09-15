using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B1*1cx*W*k0TEQS*u";

		var expected = new B1_BeginningSegmentForBookingOrPickUpDelivery()
		{
			TransactionSetIdentifierCode = "1cx",
			ShipmentIdentificationNumber = "W",
			BookingDate = "k0TEQS",
			ReservationActionCode = "u",
		};

		var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickUpDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new B1_BeginningSegmentForBookingOrPickUpDelivery();
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
