using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class P1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P1*D*lFZqus*mrf*ECE3*z*p*8";

		var expected = new P1_PickUp()
		{
			PickUpOrDeliveryCode = "D",
			PickUpDate = "lFZqus",
			DateTimeQualifier = "mrf",
			PickUpTime = "ECE3",
			EquipmentInitial = "z",
			EquipmentNumber = "p",
			NumberOfShipments = 8,
		};

		var actual = Map.MapObject<P1_PickUp>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lFZqus", true)]
	public void Validation_RequiredPickUpDate(string pickUpDate, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.DateTimeQualifier = "mrf";
		subject.PickUpDate = pickUpDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mrf", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P1_PickUp();
		subject.PickUpDate = "lFZqus";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
