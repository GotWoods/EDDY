using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class P1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P1*F*z1D3QTOb*8oR*ex9Q*K*k*2";

		var expected = new P1_Pickup()
		{
			PickupOrDeliveryCode = "F",
			PickupDate = "z1D3QTOb",
			DateTimeQualifier = "8oR",
			PickupTime = "ex9Q",
			EquipmentInitial = "K",
			EquipmentNumber = "k",
			NumberOfShipments = 2,
		};

		var actual = Map.MapObject<P1_Pickup>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z1D3QTOb", true)]
	public void Validation_RequiredPickupDate(string pickupDate, bool isValidExpected)
	{
		var subject = new P1_Pickup();
		subject.DateTimeQualifier = "8oR";
		subject.PickupDate = pickupDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8oR", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P1_Pickup();
		subject.PickupDate = "z1D3QTOb";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
