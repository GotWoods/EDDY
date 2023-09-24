using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class P1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P1*1*mHEArXvo*0qf*kqi3*K*T*7";

		var expected = new P1_PickUp()
		{
			PickUpOrDeliveryCode = "1",
			PickUpDate = "mHEArXvo",
			DateTimeQualifier = "0qf",
			PickUpTime = "kqi3",
			EquipmentInitial = "K",
			EquipmentNumber = "T",
			NumberOfShipments = 7,
		};

		var actual = Map.MapObject<P1_PickUp>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mHEArXvo", true)]
	public void Validation_RequiredPickUpDate(string pickUpDate, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.DateTimeQualifier = "0qf";
		subject.PickUpDate = pickUpDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0qf", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.PickUpDate = "mHEArXvo";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
