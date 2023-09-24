using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class P2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P2*l*rBc2ac7i*InM";

		var expected = new P2_Delivery()
		{
			PickUpOrDeliveryCode = "l",
			DeliveryDate = "rBc2ac7i",
			DateTimeQualifier = "InM",
		};

		var actual = Map.MapObject<P2_Delivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rBc2ac7i", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new P2_Delivery();
		subject.DateTimeQualifier = "InM";
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("InM", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P2_Delivery();
		subject.DeliveryDate = "rBc2ac7i";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
