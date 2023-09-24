using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class P1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P1*g*pNPxPSdF*SLN*QElM*2*z*3";

		var expected = new P1_Pickup()
		{
			PickupOrDeliveryCode = "g",
			PickupDate = "pNPxPSdF",
			DateTimeQualifier = "SLN",
			PickupTime = "QElM",
			EquipmentInitial = "2",
			EquipmentNumber = "z",
			NumberOfShipments = 3,
		};

		var actual = Map.MapObject<P1_Pickup>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pNPxPSdF", true)]
	public void Validation_RequiredPickupDate(string pickupDate, bool isValidExpected)
	{
		var subject = new P1_Pickup();
		subject.DateTimeQualifier = "SLN";
		subject.PickupDate = pickupDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SLN", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P1_Pickup();
		subject.PickupDate = "pNPxPSdF";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
