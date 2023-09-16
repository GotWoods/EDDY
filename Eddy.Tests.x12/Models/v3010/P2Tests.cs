using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class P2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P2*t*yZuYJk*Lsa";

		var expected = new P2_Delivery()
		{
			PickUpOrDeliveryCode = "t",
			DeliveryDate = "yZuYJk",
			DateTimeQualifier = "Lsa",
		};

		var actual = Map.MapObject<P2_Delivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yZuYJk", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new P2_Delivery();
		subject.DateTimeQualifier = "Lsa";
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lsa", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P2_Delivery();
		subject.DeliveryDate = "yZuYJk";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
