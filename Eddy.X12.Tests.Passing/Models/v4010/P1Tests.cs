using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class P1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P1*S*GUOlydI7*C50*xSFT*S*K*9";

		var expected = new P1_PickUp()
		{
			PickUpOrDeliveryCode = "S",
			PickUpDate = "GUOlydI7",
			DateTimeQualifier = "C50",
			PickUpTime = "xSFT",
			EquipmentInitial = "S",
			EquipmentNumber = "K",
			NumberOfShipments = 9,
		};

		var actual = Map.MapObject<P1_PickUp>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GUOlydI7", true)]
	public void Validation_RequiredPickUpDate(string pickUpDate, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.DateTimeQualifier = "C50";
		subject.PickUpDate = pickUpDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C50", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.PickUpDate = "GUOlydI7";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
