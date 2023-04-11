using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class P2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P2*8*xzUITyfO*aCk";

		var expected = new P2_DeliveryDateInformation()
		{
			PickupOrDeliveryCode = "8",
			DeliveryDate = "xzUITyfO",
			DateTimeQualifier = "aCk",
		};

		var actual = Map.MapObject<P2_DeliveryDateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xzUITyfO", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new P2_DeliveryDateInformation();
		subject.DateTimeQualifier = "aCk";
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aCk", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P2_DeliveryDateInformation();
		subject.DeliveryDate = "xzUITyfO";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
